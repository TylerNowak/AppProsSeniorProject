using System;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// The Home Model handles the display message as well as retrieving input for login
/// </summary>
namespace AppAdeptsApp.Models
{
    public class Home
    {
        private readonly DayOfWeek _dayOfWeek;

        // the view doesn't need to know anything about time other than the day of the week.
        public Home(DayOfWeek dayOfWeek)
        {
            _dayOfWeek = dayOfWeek;
        }

        public Home()
        {

        }

        [Required(ErrorMessage = "Please enter your username")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

        public string LockoutMessage = "Maximum login attempts reached. Please contact support for further assistance.";

        public string DayMessage()
        {
            switch (_dayOfWeek)
            {
                case DayOfWeek.Monday:
                    return "It's a new week! Go get 'em!";
                case DayOfWeek.Tuesday:
                    return "Happy Tuesday. It's good to have you.";
                case DayOfWeek.Wednesday:
                    return "Wednesday. We're half-way there!";
                case DayOfWeek.Thursday:
                    return "Almost to Friday. Let's finish strong!";
                case DayOfWeek.Friday:
                    return "Hooray, it's Friday!";
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    return "Good to see you! Remember to take some time to rest after work!";
                default:
                    return "Hey there! It's good to see you!";
            }
        }
    }
}