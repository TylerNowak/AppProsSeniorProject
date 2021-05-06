using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppAdeptsApp.Models;
using AppAdeptsApp.Shared.Interfaces;

namespace AppAdeptsApp.Shared
{
    /// <summary>
    /// Provide a base from which all our main pages can extend. Each page should have a Logout, so we can just use this once.
    /// </summary>
    public abstract class BasePageController : Controller
    {
        private readonly IUserInfo _user;

        protected BasePageController(IUserInfo userInfo)
        {
            _user = userInfo;
        }
        
        public IActionResult Logout()
        {
            _user.loggedIn = false;
            return RedirectToRoute("Home");
        }

        public IActionResult Back()
        {
            return RedirectToRoute("Dashboard");
        }

        public ActionResult Chat()
        {
            return RedirectToRoute("Chat");
        }

        public ActionResult Submit()
        {
            return RedirectToRoute("Submit");
        }

        public ActionResult Edit()
        {
            return RedirectToRoute("Edit");
        }
    }
}