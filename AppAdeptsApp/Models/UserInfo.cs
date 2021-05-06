using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdeptsApp.Shared.Interfaces;

/// <summary>
/// The UserInfo Model stores information about the user to be used throughout the system
/// </summary>
namespace AppAdeptsApp.Models
{
    public class UserInfo: IUserInfo
    {
        public string UserID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jiraKey { get; set; }
        public string chatChannel { get; set; }
        public bool loggedIn { get; set; }
    }
}
