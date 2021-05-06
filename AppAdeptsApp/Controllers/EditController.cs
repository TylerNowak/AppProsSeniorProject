using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SlackNet;
using AppAdeptsApp.Models;
using AppAdeptsApp.Controllers;
using AppAdeptsApp.Shared;
using AppAdeptsApp.Shared.Interfaces;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net.Http.Headers;
using static AppAdeptsApp.Models.UserDashboard;
using Newtonsoft.Json;
using System.Text;

/// <summary>
/// The EditController handles how users edit issues from the issue cards on the Dashboard
/// </summary>
namespace AppAdeptsApp.Controllers
{
    public class EditController : BasePageController
    {
        private readonly IUserInfo _user;
        public Chat.Messages messageHistory;

        public readonly string channel;
        public readonly string token;
        public SlackApiClient api;

        private Edit editModel = new Edit();

        string apiString = "";//Omitted


        /// <summary>
        /// Retrieves the user info from UserInfo Model
        /// Initiates Slack API
        /// </summary>
        public EditController(IUserInfo user) : base(user)
        {
            _user = user;
            channel = user.chatChannel;
            token = "";//Omitted
            api = new SlackApiClient(token);
        }

        /// <summary>
        /// Retrieves the Issue Key from the Edit model for the issue being edited
        /// </summary>
        /// <returns> if user is logged in, returns to the EditView with the Issue Key, else returns to Login Screen</returns>
        public ActionResult Index(string id)
        {
            if (_user.loggedIn)
            {
                editModel.IssueId = id;
                TempData["id"] = id;
                return View(editModel);
            }
            else
            {
                return RedirectToRoute("Home");
            }
        }

        /// <summary>
        /// Handles posting the user's edited issue with attachments and sends a Notification to the specified Slack Channel
        /// </summary>
        /// <param name="model"></param>
        /// /// <param name="iFormFile"></param>
        /// <returns>Back to Dashboard</returns>
        [HttpPost]
        public async Task<ActionResult> EditIssue(Edit model, [FromForm(Name = "AttachmentField")] IFormFile iFormFile)
        {
            var issueId = (string)TempData["id"];

            //Creating API call address and headers
            using var client = new HttpClient { BaseAddress = new Uri(apiString) };
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + "");//Omitted

            //Call to API to retrieve issue details
            HttpResponseMessage Res = await client.GetAsync(apiString + issueId);
            var Response = Res.Content.ReadAsStringAsync().Result;

            //Sets model issue to data returned from api call
            UserDashboard.Issue issue = JsonConvert.DeserializeObject<UserDashboard.Issue>(Response);

            //Sets model description to additional information passed from view
            issue.fields.description += "\nEdit to issue:\n" + model.EditText;

            //Turns model data into json object then content data for api call
            var json = JsonConvert.SerializeObject(issue);
            HttpContent payload = new StringContent(json, Encoding.UTF8, "application/json");

            //Determines if there is an uploaded file and if it complies to validation via FileValidationController
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

                Res = await client.PostAsync(apiString + issueId + "/attachments", content);
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                Res = await client.PutAsync(apiString + issueId, payload);
                EmpResponse = Res.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Res = await client.PutAsync(apiString + issueId, payload);
                var EmpResponse = Res.Content.ReadAsStringAsync().Result;
            }

            //Crafts the Slack Notification Message
            await api.Chat.PostMessage(new SlackNet.WebApi.Message
            {
                Channel = channel,
                Text = "Edit Issue: " + issueId + "\n" + model.EditText + "\nSubmitted by: " + _user.firstName + " " + _user.lastName
            });

            return RedirectToRoute("Dashboard");
        }
    }
}
