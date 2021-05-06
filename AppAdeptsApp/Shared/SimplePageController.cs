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
    public abstract class SimplePageController : BasePageController
    {
        private readonly IUserInfo _user;

        protected SimplePageController(IUserInfo userInfo): base(userInfo)
        {
            _user = userInfo;
        }
        
        // Return the Index view for this controller
        public IActionResult Index()
        {
            return _user.loggedIn ? View() : RedirectToRoute("Home");
        }
    }
}