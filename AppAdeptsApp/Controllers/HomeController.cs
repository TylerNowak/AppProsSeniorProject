using System;
using Microsoft.AspNetCore.Mvc;
using AppAdeptsApp.Models;
using AppAdeptsApp.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using AppAdeptsApp.Shared;
using MySql.Data.MySqlClient;


/// <summary>
/// The Home Controller handles logging into the system
/// This is the screen that users return to after logging out
/// </summary>
namespace AppAdeptsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _dataLink;
        
        /// <summary>
        /// Retrieves the datalink string from the configuration file
        /// </summary>
        /// <param name="configuration"></param>
        public HomeController(IConfiguration configuration)
        {
             _dataLink = configuration.GetSection("dataLink").Value;
        }

        /// <summary>
        /// Displays the defined message for the day of week
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>The model to view</returns>
        public IActionResult Index([FromServices] IDateTime dateTime)
        {
            // Use dependency injection (DI) to insert a more "DRY" and less effect-ful time.
            var model = new Home(dateTime.Now.DayOfWeek);
            return View(model);
        }

        /// <summary>
        /// Performs the action of logging in after user inputs their information
        /// after logged, sets the UserInfo Model to the information in the Database
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="user"></param>
        /// <returns>if successfully logged in, returns to USer to teir Dashboard, else returns back to login</returns>
        [HttpPost]
        public IActionResult Login(string email, string password, [FromServices] IUserInfo user)
        {
            try
            {
                //Sets base route
                var route = "Home";

                //Calls DBRead with input username
                if (!InputValidationController.ValidateEmail(email))
                {
                    return RedirectToRoute(route);
                }
                
                MySqlDataReader reader = DBRead(email);
                
                //If the DB has the email then execute
                if (!reader.Read() || !InputValidationController.ValidatePassword(password))
                {
                    return RedirectToRoute(route);
                }
                
                //Performs a check whether the lockout is above 5 and if password is correct
                if (checkPassword(reader, password) && reader.GetInt16(6) <= 5)
                {
                    //Sets the static model to the information
                    setUserInfo(reader, user);

                    //Reset login attempts since successful
                    if (reader.GetInt32(6) != 0)
                        resetLoginAttepts(email);

                    //Since successful, now reroutes
                    route = "Dashboard";
                }
                else//If DB has email and password is incorrect, increase attempts
                {
                    increaseLoginAttepts(reader, email);
                }
                //Closes DB connection
                reader.Close();

                return RedirectToRoute(route);
            }
            catch (Exception error)
            {
                // TODO: We need to make sure this only happens in development mode
                return Error(error.ToString());
            }
        }

        /// <summary>
        /// Connects to the Database and retrieves the information for the user
        /// </summary>
        /// <param name="email"></param>
        /// <returns>returns the now valid database reader</returns>
        private MySqlDataReader DBRead(string email)
        {
            //Establishes connection
            MySqlConnection myConnection = new MySqlConnection(_dataLink);
            //Creates command to read info from DB
            MySqlCommand getUserinfo =
                new MySqlCommand("SELECT firstName, lastName, JiraKey, chatChannel, UserID, password, shouldLockout FROM Users WHERE email = @email",
                    myConnection);


            //Adding parameters
            getUserinfo.Parameters.Add("@email", MySqlDbType.VarChar);
            //Adding information at the added parameters
            getUserinfo.Parameters["@email"].Value = email;

            //Opens then Executes DB connection
            getUserinfo.Connection.Open();
            MySqlDataReader reader = getUserinfo.ExecuteReader();
            return reader;
        }

        /// <summary>
        /// Checks to see if the password is valid from the database based off of the hash
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="password"></param>
        /// <returns>Boolean</returns>
        private bool checkPassword(MySqlDataReader reader, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, reader.GetString(5));
        }

        /// <summary>
        /// After confirming user is valid, retrieves the UserInfo from database
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="user"></param>
        public void setUserInfo(MySqlDataReader reader, [FromServices] IUserInfo user)
        {
            user.firstName = reader.GetString(0);
            user.lastName = reader.GetString(1);
            user.jiraKey = reader.GetString(2);
            user.chatChannel = reader.GetString(3);
            user.UserID = reader.GetString(4);
            user.loggedIn = true;
        }

        /// <summary>
        /// If the email is valid and that password is not, increases the login attempts
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="email"></param>
        public void increaseLoginAttepts(MySqlDataReader reader, string email)
        {
            //Establishes connection
            MySqlConnection myConnection = new MySqlConnection(_dataLink);

            //Creates command to increase the attempts
            MySqlCommand increaseAttempt = new MySqlCommand("UPDATE Users set shouldLockout= @attempts WHERE email = @email",
                    myConnection);

            //Adding parameters
            increaseAttempt.Parameters.Add("@email", MySqlDbType.VarChar);
            increaseAttempt.Parameters.Add("@attempts", MySqlDbType.Int32);
            //Adding information at the added parameters
            increaseAttempt.Parameters["@email"].Value = email;
            increaseAttempt.Parameters["@attempts"].Value = reader.GetInt32(6) + 1;

            //Opens then Executes DB connection
            increaseAttempt.Connection.Open();
            increaseAttempt.ExecuteReader();
        }

        /// <summary>
        /// Once the user logins in successfully, reset the login attempts in database
        /// </summary>
        /// <param name="email"></param>
        public void resetLoginAttepts(string email)
        {
            //Establishes connection
            MySqlConnection myConnection = new MySqlConnection(_dataLink);

            //Creates command to increase the attempts
            MySqlCommand resetAttempt = new MySqlCommand("UPDATE Users set shouldLockout = 0 WHERE email = @email",
                    myConnection);

            //Adding parameters
            resetAttempt.Parameters.Add("@email", MySqlDbType.VarChar);

            //Adding information at the added parameters
            resetAttempt.Parameters["@email"].Value = email;

            //Opens then Executes DB connection
            resetAttempt.Connection.Open();
            resetAttempt.ExecuteReader();
        }

        /// <summary>
        /// For development use only
        /// </summary>
        /// <param name="message"></param>
        /// <returns>returns error message</returns>
        public IActionResult Error(string message)
        {
            return View(message);
        }

        /// <summary>
        /// Handles the privacy policy
        /// </summary>
        /// <returns>privacy policy</returns>
        public IActionResult Privacy()
            {
                throw new NotImplementedException();
            }
    }
}
