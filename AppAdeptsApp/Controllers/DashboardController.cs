using AppAdeptsApp.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using AppAdeptsApp.Models;
using AppAdeptsApp.Shared.Interfaces;

namespace AppAdeptsApp.Controllers
{
    /// <summary>
    /// The Dashboard Controller handles displaying the Jira issue cards
    /// and redirection to the chat functionalitty
    /// </summary>
    public class DashboardController : BasePageController
    {
        readonly string apiString = "";//Omitted
        private readonly IUserInfo _user;
        public static UserDashboard.Root list;

        /// <summary>
        /// Dependency injection of the UserInfo
        /// </summary>
        /// <param name="userInfo"></param>
        public DashboardController(IUserInfo userInfo) : base(userInfo)
        {
            _user = userInfo;
        }

        /// <summary>
        /// JiraAuth authenticates with Jira
        /// </summary>
        /// <returns>returns the list of issues from jira</returns>
        async Task<IActionResult> JiraAuth()
        {
            //Adding Client info
            using var client = new HttpClient {BaseAddress = new Uri(apiString)};
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //TO DO: Move the token to the config file
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + "");//Omitted

            //GET to receive the client issues
            //TO DO: Perform logic to sort based on project ID from DB
            HttpResponseMessage Res = await client.GetAsync("rest/api/2/search");
            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

            //Creating a list of issues from the ones from GET
            list = JsonConvert.DeserializeObject<UserDashboard.Root>(EmpResponse);
            List<UserDashboard.Issue> item = list.Issues;

            return View(list);
        }

        /// <summary>
        /// Filters the Jira Issues based off of the UserInfo
        /// </summary>
        /// <returns>Returns a redirect either back to home or the Dashboard with Jira Cards</returns>
        public async Task<IActionResult> Index()
        {
            ViewData["JiraKey"] = _user.jiraKey;
            return _user.loggedIn ? await JiraAuth() : RedirectToRoute("Home");
        }
    }
}