using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppProsAdminApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UserID_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("UserID should be in compliance with the Jira Key followed by numbers\n i.e: JIRAKEY0001",UserID);
        }

        private void email_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Please use the clients requested email", email);
        }

        private void jiraKey_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("The Jira Key is made on Project setup. \n This can be found before the '-' on issues", jiraKey);
        }

        private void chatChannel_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("The Slack channel is found by opening Slack in a browser and copying the end of the URL \n This typically starts with 'C'", chatChannel);
        }

        private void resetEmail_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Please use the email inside the Database", resetEmail);
        }

        private void submitUser_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Updates the Database with the new user", submitUser);
        }

        private void updatePassword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Updates the Database with new password for the user", updatePassword);
        }
        private void password_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Please enter a password that is 10 digits\nPassword must have at least 1 number and 1 special character", password);
        }

        private void submitUser_Click(object sender, EventArgs e)
        {
            if (validateUserID() && validateFirstName() && validateLastName() && validateEmail() && validatePassword() && validateJiraKey() && validateChatChannel())
            {
                string dataLink = "datasource=127.0.0.1;port=3306;username=root;password=;database=appadepts";
                MySqlConnection myConnection = new MySqlConnection(dataLink);

                MySqlCommand addUser = new MySqlCommand("INSERT INTO Users (UserID, firstName, lastName, email, password, jiraKey, chatChannel, jiraChannel, shouldLockout) VALUES (@UserID, @firstName, @lastName, @email, @password, @jiraKey, @chatChannel, @jiraChannel, 0)",
                        myConnection);

                addUser.Parameters.Add("@UserID", MySqlDbType.VarChar);
                addUser.Parameters.Add("@firstName", MySqlDbType.VarChar);
                addUser.Parameters.Add("@lastName", MySqlDbType.VarChar);
                addUser.Parameters.Add("@email", MySqlDbType.VarChar);
                addUser.Parameters.Add("@password", MySqlDbType.VarChar);
                addUser.Parameters.Add("@jiraKey", MySqlDbType.VarChar);
                addUser.Parameters.Add("@chatChannel", MySqlDbType.VarChar);
                addUser.Parameters.Add("@jiraChannel", MySqlDbType.VarChar);

                addUser.Parameters["@UserID"].Value = UserID.Text;
                addUser.Parameters["@firstName"].Value = firstName.Text;
                addUser.Parameters["@lastName"].Value = lastName.Text;
                addUser.Parameters["@email"].Value = email.Text;
                addUser.Parameters["@password"].Value = BCrypt.Net.BCrypt.HashPassword(password.Text);
                addUser.Parameters["@jiraKey"].Value = jiraKey.Text;
                addUser.Parameters["@chatChannel"].Value = chatChannel.Text;
                addUser.Parameters["@jiraChannel"].Value = chatChannel.Text;

                addUser.Connection.Open();
                addUser.ExecuteReader();
                UserID.Clear();
                firstName.Clear();
                lastName.Clear();
                email.Clear();
                password.Clear();
                jiraKey.Clear();
                chatChannel.Clear();
            } 
        }
        private void updatePassword_Click(object sender, EventArgs e)
        {
            string dataLink = "datasource=127.0.0.1;port=3306;username=root;password=;database=appadepts";
            MySqlConnection myConnection = new MySqlConnection(dataLink);

            MySqlCommand checkEmail = new MySqlCommand("Select email FROM Users WHERE email=@email",
                    myConnection);
            checkEmail.Parameters.Add("@email", MySqlDbType.VarChar);
            checkEmail.Parameters["@email"].Value = resetEmail.Text;

            checkEmail.Connection.Open();
            MySqlDataReader reader = checkEmail.ExecuteReader();

            if (reader.Read() && (resetPassword.Text != "" && confirmPassword.Text != "") && (resetPassword.Text == confirmPassword.Text))
            {
                checkEmail.Connection.Close();
                errorProvider1.Clear();
                MySqlCommand updatePassword = new MySqlCommand("UPDATE Users set shouldLockout= 0, password = @password WHERE email = @email",
                    myConnection);

                updatePassword.Parameters.Add("@email", MySqlDbType.VarChar);
                updatePassword.Parameters.Add("@password", MySqlDbType.VarChar);

                updatePassword.Parameters["@email"].Value = resetEmail.Text;
                updatePassword.Parameters["@password"].Value = BCrypt.Net.BCrypt.HashPassword(confirmPassword.Text);
                updatePassword.Connection.Open();
                updatePassword.ExecuteReader();
                resetEmail.Clear();
                confirmPassword.Clear();
                resetPassword.Clear();
                updatePassword.Connection.Close();
            }
            else
            {
                if(resetPassword.Text == "")
                {
                    errorProvider1.SetError(resetPassword, "Please enter a password!");
                }
                else if(confirmPassword.Text == "")
                {
                    errorProvider1.SetError(confirmPassword, "Please confirm password!");
                }
                else if(resetPassword.Text != confirmPassword.Text)
                {
                    errorProvider1.SetError(confirmPassword, "Passwords do not match!");
                }
                else
                    errorProvider1.SetError(resetEmail, "User does not exist!");
            }

        }

        private void UserID_Validating(object sender, CancelEventArgs e)
        {
            validateUserID();
        }

        private bool validateUserID()
        {
            bool valUserID = false;
            if(UserID.Text == "")
            {
                errorProvider1.SetError(UserID, "Please enter a User ID");
                valUserID = false;
            }
            else
            {
                errorProvider1.Clear();
                valUserID = true;
            }
            return valUserID;
        }

        private void firstName_Validating(object sender, CancelEventArgs e)
        {
            validateFirstName();
        }

        private bool validateFirstName()
        {
            bool valFirst = false;
            if (firstName.Text == "")
            {
                errorProvider1.SetError(firstName, "Please enter the user's First Name");
                valFirst = false;
            }
            else
            {
                errorProvider1.Clear();
                valFirst = true;
            }
            return valFirst;
        }

        private void lastName_Validating(object sender, CancelEventArgs e)
        {
            validateLastName();
        }

        private bool validateLastName()
        {
            bool valLast = false;
            if (lastName.Text == "")
            {
                errorProvider1.SetError(lastName, "Please enter the user's Last Name");
                valLast = false;
            }
            else
            {
                errorProvider1.Clear();
                valLast = true;
            }
            return valLast;
        }

        private void email_Validating(object sender, CancelEventArgs e)
        {
            validateEmail();
        }

        private bool validateEmail()
        {
            bool valEmail = false;
            if (email.Text == "")
            {
                errorProvider1.SetError(email, "Please enter a user's Email");
                valEmail = false;
            }
            else if (!email.Text.Contains("@") || !email.Text.Contains("."))
            {
                errorProvider1.SetError(email, "Please enter a valid Email");
                valEmail = false;
            }
            else
            {
                errorProvider1.Clear();
                valEmail = true;
            }
            return valEmail;
        }

        private void password_Validating(object sender, CancelEventArgs e)
        {
            validatePassword();
        }

        private bool validatePassword()
        {
            bool valPassword = false;
            if (password.Text == "")
            {
                errorProvider1.SetError(password, "Please enter the User's Password");
                valPassword = false;
            }
            else if (password.Text.Length<10)
            {
                errorProvider1.SetError(password, "Please enter a password that is at least 10 characters long");
                valPassword = false;
            }
            else if (!hasSpecialChar(password.Text))
            {
                errorProvider1.SetError(password, "Please enter at least one Special Character");
                valPassword = false;
            }
            else if (!hasNumChar(password.Text))
            {
                errorProvider1.SetError(password, "Please enter at least one Number");
                valPassword = false;
            }
            else
            {
                errorProvider1.Clear();
                valPassword = true;
            }
            return valPassword;
        }
        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,^=+*`~";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public static bool hasNumChar(string input)
        {
            string numChar = @"1234567890";
            foreach (var item in numChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        private void jiraKey_Validating(object sender, CancelEventArgs e)
        {
            validateJiraKey();
        }

        private bool validateJiraKey()
        {
            bool valJiraKey = false;
            if (jiraKey.Text == "")
            {
                errorProvider1.SetError(jiraKey, "Please enter a Jira Key");
                valJiraKey = false;
            }
            else
            {
                errorProvider1.Clear();
                valJiraKey = true;
            }
            return valJiraKey;
        }

        private void chatChannel_Validating(object sender, CancelEventArgs e)
        {
            validateChatChannel();
        }

        private bool validateChatChannel()
        {
            bool valChatChannel = false;
            if (chatChannel.Text == "")
            {
                errorProvider1.SetError(chatChannel, "Please enter a Slack Channel for Chatting with user");
                valChatChannel = false;
            }
            else
            {
                errorProvider1.Clear();
                valChatChannel = true;
            }
            return valChatChannel;
        }

        private void resetEmail_Validating(object sender, CancelEventArgs e)
        {
            validateEmailReset();
        }
        private bool validateEmailReset()
        {
            bool valEmail = false;
            if (resetEmail.Text == "")
            {
                errorProvider1.SetError(resetEmail, "Please enter a user's Email");
                valEmail = false;
            }
            else if (!resetEmail.Text.Contains("@") || !resetEmail.Text.Contains("."))
            {
                errorProvider1.SetError(resetEmail, "Please enter a valid Email");
                valEmail = false;
            }
            else
            {
                errorProvider1.Clear();
                valEmail = true;
            }
            return valEmail;
        }

        private void resetPassword_Validating(object sender, CancelEventArgs e)
        {
            validatePasswordReset();
        }

        private bool validatePasswordReset()
        {
            bool valPassword = false;
            if (resetPassword.Text == "")
            {
                errorProvider1.SetError(resetPassword, "Please enter the User's Password");
                valPassword = false;
            }
            else if (resetPassword.Text.Length < 10)
            {
                errorProvider1.SetError(resetPassword, "Please enter a password that is at least 10 characters long");
                valPassword = false;
            }
            else if (!hasSpecialChar(resetPassword.Text))
            {
                errorProvider1.SetError(resetPassword, "Please enter at least one Special Character");
                valPassword = false;
            }
            else if (!hasNumChar(resetPassword.Text))
            {
                errorProvider1.SetError(resetPassword, "Please enter at least one Number");
                valPassword = false;
            }
            else
            {
                errorProvider1.Clear();
                valPassword = true;
            }
            return valPassword;
        }

        private void confirmPassword_Validating(object sender, CancelEventArgs e)
        {
            validatePasswordConfirm();
        }

        private bool validatePasswordConfirm()
        {
            bool valPasswordConfirm = true;
            if (!(resetPassword.Text == confirmPassword.Text))
            {
                errorProvider1.SetError(confirmPassword, "Please enter matching Passwords");
                valPasswordConfirm = false;
            }
            else
            {
                errorProvider1.Clear();
                valPasswordConfirm = true;
            }
            return valPasswordConfirm;
        }

        private void unlock_Click(object sender, EventArgs e)
        {
            string dataLink = "datasource=127.0.0.1;port=3306;username=root;password=;database=appadepts";
            MySqlConnection myConnection = new MySqlConnection(dataLink);

            MySqlCommand checkEmail = new MySqlCommand("Select email FROM Users WHERE email=@email",
                    myConnection);
            checkEmail.Parameters.Add("@email", MySqlDbType.VarChar);
            checkEmail.Parameters["@email"].Value = unlockEmail.Text;

            checkEmail.Connection.Open();
            MySqlDataReader reader = checkEmail.ExecuteReader();

            if (reader.Read())
            {
                errorProvider1.Clear();
                checkEmail.Connection.Close();
                errorProvider1.Clear();
                MySqlCommand unlockuser= new MySqlCommand("UPDATE Users set shouldLockout = 0 WHERE email = @email",
                    myConnection);

                unlockuser.Parameters.Add("@email", MySqlDbType.VarChar);

                unlockuser.Parameters["@email"].Value = unlockEmail.Text;

                unlockuser.Connection.Open();
                unlockuser.ExecuteReader();
                unlockEmail.Clear();
            }
            else
            {
                errorProvider1.SetError(unlockEmail, "Please enter a valid user!");
            }

        }

        private void LockEmail_Click(object sender, EventArgs e)
        {
            string dataLink = "datasource=127.0.0.1;port=3306;username=root;password=;database=appadepts";
            MySqlConnection myConnection = new MySqlConnection(dataLink);

            MySqlCommand checkEmail = new MySqlCommand("Select email FROM Users WHERE email=@email",
                    myConnection);
            checkEmail.Parameters.Add("@email", MySqlDbType.VarChar);
            checkEmail.Parameters["@email"].Value = unlockEmail.Text;

            checkEmail.Connection.Open();
            MySqlDataReader reader = checkEmail.ExecuteReader();

            if (reader.Read())
            {
                errorProvider1.Clear();
                checkEmail.Connection.Close();
                errorProvider1.Clear();
                MySqlCommand unlockuser = new MySqlCommand("UPDATE Users set shouldLockout = 10 WHERE email = @email",
                    myConnection);

                unlockuser.Parameters.Add("@email", MySqlDbType.VarChar);

                unlockuser.Parameters["@email"].Value = unlockEmail.Text;

                unlockuser.Connection.Open();
                unlockuser.ExecuteReader();
                unlockEmail.Clear();
            }
            else
            {
                errorProvider1.SetError(lockEmail, "Please enter a valid user!");
            }
        }
    }
}
