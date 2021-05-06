using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static AppAdeptsApp.Models.UserDashboard;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using AppAdeptsApp.Shared.Interfaces;
using AppAdeptsApp.Shared;
using System.Text;
using AppAdeptsApp.Models;
using Microsoft.AspNetCore.Http;
using SlackNet;

namespace AppAdeptsApp.Controllers
{
    public class SubmitController : BasePageController
    {
        private readonly IUserInfo _user;
        public readonly string channel;
        public readonly string token;
        public SlackApiClient api;

        public SubmitController(IUserInfo user) : base(user)
        {
            _user = user;
            channel = user.chatChannel;
            token = "";//Omitted
            api = new SlackApiClient(token);
        }
        public IActionResult Index()
        {
            if (_user.loggedIn)
            {
                return View();
            }
            else
            {
                return RedirectToRoute("Home");
            }
        }

        [HttpPost]
        public async Task<ActionResult> SendIssue(Submit model, [FromForm(Name = "AttachmentField")] IFormFile iFormFile)
        {
            string apiString = "";//Omitted
            using var client = new HttpClient { BaseAddress = new Uri(apiString + "rest/api/2/issue") };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + "");//Omitted

            Issue issue = new Issue();
            issue.fields = new Fields();
            issue.fields.project = new Project();
            issue.fields.issuetype = new Issuetype();
            issue.fields.project.key = _user.jiraKey;
            issue.fields.summary = model.SummaryField;
            issue.fields.description = model.DescriptionField;

            issue.fields.issuetype.id = "10001";

            var json = JsonConvert.SerializeObject(issue);
            HttpContent issueContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Use if JSon is not created properly
            //System.Diagnostics.Debug.WriteLine(json);
            
            HttpResponseMessage Res = await client.PostAsync(apiString + "rest/api/2/issue", issueContent);
            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

            //Creates an issue for us to lookup the key
            Issue returned = JsonConvert.DeserializeObject<Issue>(EmpResponse);

            System.Diagnostics.Debug.WriteLine((iFormFile != null));
            if ((iFormFile != null) && FileValidationController.AttachmentContentValidation(iFormFile) && FileValidationController.AttachmentExtensionValidation(iFormFile))
            {
                client.DefaultRequestHeaders.Add("X-Atlassian-Token", "no-check");

                //Creates a temporary file with the contents of the uploaded file
                var filePath = Path.GetTempFileName();
                using (var stream = new FileStream(filePath,
                FileMode.Create))
                {
                    await iFormFile.CopyToAsync(stream);
                }

                MultipartFormDataContent content = new MultipartFormDataContent();
                HttpContent fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(filePath));
                content.Add(fileContent, "file", "Attachment");

                Res = await client.PostAsync(apiString + "rest/api/2/issue/" + returned.key + "/attachments", content);
                EmpResponse = Res.Content.ReadAsStringAsync().Result;
            }

            //Crafts the Slack Notification Message
            await api.Chat.PostMessage(new SlackNet.WebApi.Message
            {
                Channel = channel,
                Text = "New Issue: " + returned.key + "\n" + model.SummaryField + "\n" + model.DescriptionField + "\nSubmitted by: " + _user.firstName + " " +_user.lastName
            });

            return RedirectToRoute("Dashboard");
        }
    }
}
