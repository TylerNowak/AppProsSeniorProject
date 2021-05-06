/// <summary>
/// The UserInfo Interface stores information about the user to be used throughout the system
/// </summary>
namespace AppAdeptsApp.Shared.Interfaces
{
    public interface IUserInfo
    {
        public string UserID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string jiraKey { get; set; }
        public string chatChannel { get; set; }      
        public bool loggedIn { get; set; }
    }
}