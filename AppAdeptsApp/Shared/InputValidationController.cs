using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdeptsApp.Shared
{
    /// <summary>
    /// Validates user input before connecting to database
    /// </summary>
    public class InputValidationController
    {
        /// <summary>
        /// Determines if the input information is an email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Boolean</returns>
        public static bool ValidateEmail(string email)
        {
            return (email.Contains("@") && email.Contains(".") && !email.Contains("*") && !email.Contains(" "));
        }

        /// <summary>
        /// Determines if the input is a valid password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Boolean</returns>
        public static bool ValidatePassword(string password)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,^=+*`~";
            string num = @"1234567890";
            bool spcChar = false;
            bool numChar = false;

            foreach (var item in specialChar)
            {
                if (password.Contains(item))
                    spcChar = true;
            }

            foreach (var item in num)
            {
                if (password.Contains(item))
                    numChar = true;
            }

            return (!password.Contains("SELECT") && !password.Contains(" ") && !password.Contains("INSERT") && !password.Contains("UPDATE") && (password.Length >= 10) && spcChar && numChar);
        }
    }
}
