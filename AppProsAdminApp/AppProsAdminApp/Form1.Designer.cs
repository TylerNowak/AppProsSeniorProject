
namespace AppProsAdminApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UserID = new System.Windows.Forms.TextBox();
            this.firstName = new System.Windows.Forms.TextBox();
            this.lastName = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.jiraKey = new System.Windows.Forms.TextBox();
            this.chatChannel = new System.Windows.Forms.TextBox();
            this.submitUser = new System.Windows.Forms.Button();
            this.updatePassword = new System.Windows.Forms.Button();
            this.resetPassword = new System.Windows.Forms.TextBox();
            this.resetEmail = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.UserIDLabel = new System.Windows.Forms.Label();
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.jiraKeyLabel = new System.Windows.Forms.Label();
            this.chatChannelLabel = new System.Windows.Forms.Label();
            this.resetEmailLabel = new System.Windows.Forms.Label();
            this.resetPasswordLabel = new System.Windows.Forms.Label();
            this.confirmPassword = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabel = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.unlockEmail = new System.Windows.Forms.TextBox();
            this.unlock = new System.Windows.Forms.Button();
            this.lockEmail = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // UserID
            // 
            this.UserID.Location = new System.Drawing.Point(85, 34);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(100, 23);
            this.UserID.TabIndex = 0;
            this.UserID.MouseHover += new System.EventHandler(this.UserID_MouseHover);
            this.UserID.Validating += new System.ComponentModel.CancelEventHandler(this.UserID_Validating);
            // 
            // firstName
            // 
            this.firstName.Location = new System.Drawing.Point(85, 78);
            this.firstName.Name = "firstName";
            this.firstName.Size = new System.Drawing.Size(100, 23);
            this.firstName.TabIndex = 1;
            this.firstName.Validating += new System.ComponentModel.CancelEventHandler(this.firstName_Validating);
            // 
            // lastName
            // 
            this.lastName.Location = new System.Drawing.Point(85, 120);
            this.lastName.Name = "lastName";
            this.lastName.Size = new System.Drawing.Size(100, 23);
            this.lastName.TabIndex = 2;
            this.lastName.Validating += new System.ComponentModel.CancelEventHandler(this.lastName_Validating);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(85, 163);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 23);
            this.email.TabIndex = 3;
            this.email.MouseHover += new System.EventHandler(this.email_MouseHover);
            this.email.Validating += new System.ComponentModel.CancelEventHandler(this.email_Validating);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(85, 206);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(100, 23);
            this.password.TabIndex = 4;
            this.password.UseSystemPasswordChar = true;
            this.password.MouseHover += new System.EventHandler(this.password_MouseHover);
            this.password.Validating += new System.ComponentModel.CancelEventHandler(this.password_Validating);
            // 
            // jiraKey
            // 
            this.jiraKey.Location = new System.Drawing.Point(85, 250);
            this.jiraKey.Name = "jiraKey";
            this.jiraKey.Size = new System.Drawing.Size(100, 23);
            this.jiraKey.TabIndex = 5;
            this.jiraKey.MouseHover += new System.EventHandler(this.jiraKey_MouseHover);
            this.jiraKey.Validating += new System.ComponentModel.CancelEventHandler(this.jiraKey_Validating);
            // 
            // chatChannel
            // 
            this.chatChannel.Location = new System.Drawing.Point(85, 296);
            this.chatChannel.Name = "chatChannel";
            this.chatChannel.Size = new System.Drawing.Size(100, 23);
            this.chatChannel.TabIndex = 6;
            this.chatChannel.MouseHover += new System.EventHandler(this.chatChannel_MouseHover);
            this.chatChannel.Validating += new System.ComponentModel.CancelEventHandler(this.chatChannel_Validating);
            // 
            // submitUser
            // 
            this.submitUser.Location = new System.Drawing.Point(71, 325);
            this.submitUser.Name = "submitUser";
            this.submitUser.Size = new System.Drawing.Size(125, 23);
            this.submitUser.TabIndex = 9;
            this.submitUser.Text = "Submit New User";
            this.submitUser.UseVisualStyleBackColor = true;
            this.submitUser.Click += new System.EventHandler(this.submitUser_Click);
            this.submitUser.MouseHover += new System.EventHandler(this.submitUser_MouseHover);
            // 
            // updatePassword
            // 
            this.updatePassword.Location = new System.Drawing.Point(388, 143);
            this.updatePassword.Name = "updatePassword";
            this.updatePassword.Size = new System.Drawing.Size(126, 23);
            this.updatePassword.TabIndex = 10;
            this.updatePassword.Text = "Update Password";
            this.updatePassword.UseVisualStyleBackColor = true;
            this.updatePassword.Click += new System.EventHandler(this.updatePassword_Click);
            this.updatePassword.MouseHover += new System.EventHandler(this.updatePassword_MouseHover);
            // 
            // resetPassword
            // 
            this.resetPassword.Location = new System.Drawing.Point(399, 77);
            this.resetPassword.Name = "resetPassword";
            this.resetPassword.Size = new System.Drawing.Size(100, 23);
            this.resetPassword.TabIndex = 11;
            this.resetPassword.UseSystemPasswordChar = true;
            this.resetPassword.Validating += new System.ComponentModel.CancelEventHandler(this.resetPassword_Validating);
            // 
            // resetEmail
            // 
            this.resetEmail.Location = new System.Drawing.Point(399, 33);
            this.resetEmail.Name = "resetEmail";
            this.resetEmail.Size = new System.Drawing.Size(100, 23);
            this.resetEmail.TabIndex = 12;
            this.resetEmail.MouseHover += new System.EventHandler(this.resetEmail_MouseHover);
            this.resetEmail.Validating += new System.ComponentModel.CancelEventHandler(this.resetEmail_Validating);
            // 
            // UserIDLabel
            // 
            this.UserIDLabel.AutoSize = true;
            this.UserIDLabel.Location = new System.Drawing.Point(41, 40);
            this.UserIDLabel.Name = "UserIDLabel";
            this.UserIDLabel.Size = new System.Drawing.Size(44, 15);
            this.UserIDLabel.TabIndex = 13;
            this.UserIDLabel.Text = "UserID:";
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(18, 81);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(67, 15);
            this.firstNameLabel.TabIndex = 14;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(18, 127);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(66, 15);
            this.lastNameLabel.TabIndex = 15;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(41, 170);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(39, 15);
            this.emailLabel.TabIndex = 16;
            this.emailLabel.Text = "Email:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(20, 209);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(60, 15);
            this.passwordLabel.TabIndex = 17;
            this.passwordLabel.Text = "Password:";
            // 
            // jiraKeyLabel
            // 
            this.jiraKeyLabel.AutoSize = true;
            this.jiraKeyLabel.Location = new System.Drawing.Point(31, 253);
            this.jiraKeyLabel.Name = "jiraKeyLabel";
            this.jiraKeyLabel.Size = new System.Drawing.Size(49, 15);
            this.jiraKeyLabel.TabIndex = 18;
            this.jiraKeyLabel.Text = "Jira Key:";
            // 
            // chatChannelLabel
            // 
            this.chatChannelLabel.AutoSize = true;
            this.chatChannelLabel.Location = new System.Drawing.Point(-2, 299);
            this.chatChannelLabel.Name = "chatChannelLabel";
            this.chatChannelLabel.Size = new System.Drawing.Size(82, 15);
            this.chatChannelLabel.TabIndex = 19;
            this.chatChannelLabel.Text = "Chat Channel:";
            // 
            // resetEmailLabel
            // 
            this.resetEmailLabel.AutoSize = true;
            this.resetEmailLabel.Location = new System.Drawing.Point(355, 37);
            this.resetEmailLabel.Name = "resetEmailLabel";
            this.resetEmailLabel.Size = new System.Drawing.Size(39, 15);
            this.resetEmailLabel.TabIndex = 21;
            this.resetEmailLabel.Text = "Email:";
            // 
            // resetPasswordLabel
            // 
            this.resetPasswordLabel.AutoSize = true;
            this.resetPasswordLabel.Location = new System.Drawing.Point(307, 81);
            this.resetPasswordLabel.Name = "resetPasswordLabel";
            this.resetPasswordLabel.Size = new System.Drawing.Size(87, 15);
            this.resetPasswordLabel.TabIndex = 22;
            this.resetPasswordLabel.Text = "New Password:";
            // 
            // confirmPassword
            // 
            this.confirmPassword.Location = new System.Drawing.Point(399, 114);
            this.confirmPassword.Name = "confirmPassword";
            this.confirmPassword.Size = new System.Drawing.Size(100, 23);
            this.confirmPassword.TabIndex = 23;
            this.confirmPassword.UseSystemPasswordChar = true;
            this.confirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.confirmPassword_Validating);
            // 
            // confirmPasswordLabel
            // 
            this.confirmPasswordLabel.AutoSize = true;
            this.confirmPasswordLabel.Location = new System.Drawing.Point(287, 117);
            this.confirmPasswordLabel.Name = "confirmPasswordLabel";
            this.confirmPasswordLabel.Size = new System.Drawing.Size(107, 15);
            this.confirmPasswordLabel.TabIndex = 24;
            this.confirmPasswordLabel.Text = "Confirm Password:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(354, 245);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Email:";
            // 
            // unlockEmail
            // 
            this.unlockEmail.Location = new System.Drawing.Point(399, 242);
            this.unlockEmail.Name = "unlockEmail";
            this.unlockEmail.Size = new System.Drawing.Size(100, 23);
            this.unlockEmail.TabIndex = 26;
            // 
            // unlock
            // 
            this.unlock.Location = new System.Drawing.Point(386, 271);
            this.unlock.Name = "unlock";
            this.unlock.Size = new System.Drawing.Size(128, 23);
            this.unlock.TabIndex = 27;
            this.unlock.Text = "Unlock User";
            this.unlock.UseVisualStyleBackColor = true;
            this.unlock.Click += new System.EventHandler(this.unlock_Click);
            // 
            // lockEmail
            // 
            this.lockEmail.Location = new System.Drawing.Point(386, 300);
            this.lockEmail.Name = "lockEmail";
            this.lockEmail.Size = new System.Drawing.Size(128, 23);
            this.lockEmail.TabIndex = 28;
            this.lockEmail.Text = "Lock User";
            this.lockEmail.UseVisualStyleBackColor = true;
            this.lockEmail.Click += new System.EventHandler(this.LockEmail_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lockEmail);
            this.Controls.Add(this.unlock);
            this.Controls.Add(this.unlockEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.confirmPasswordLabel);
            this.Controls.Add(this.confirmPassword);
            this.Controls.Add(this.resetPasswordLabel);
            this.Controls.Add(this.resetEmailLabel);
            this.Controls.Add(this.chatChannelLabel);
            this.Controls.Add(this.jiraKeyLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.Controls.Add(this.UserIDLabel);
            this.Controls.Add(this.resetEmail);
            this.Controls.Add(this.resetPassword);
            this.Controls.Add(this.updatePassword);
            this.Controls.Add(this.submitUser);
            this.Controls.Add(this.chatChannel);
            this.Controls.Add(this.jiraKey);
            this.Controls.Add(this.password);
            this.Controls.Add(this.email);
            this.Controls.Add(this.lastName);
            this.Controls.Add(this.firstName);
            this.Controls.Add(this.UserID);
            this.Name = "Form1";
            this.Text = "AppProsAdminApp";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserID;
        private System.Windows.Forms.TextBox firstName;
        private System.Windows.Forms.TextBox lastName;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox jiraKey;
        private System.Windows.Forms.TextBox chatChannel;
        private System.Windows.Forms.Button submitUser;
        private System.Windows.Forms.Button updatePassword;
        private System.Windows.Forms.TextBox resetPassword;
        private System.Windows.Forms.TextBox resetEmail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label UserIDLabel;
        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label jiraKeyLabel;
        private System.Windows.Forms.Label chatChannelLabel;
        private System.Windows.Forms.Label resetEmailLabel;
        private System.Windows.Forms.Label resetPasswordLabel;
        private System.Windows.Forms.TextBox confirmPassword;
        private System.Windows.Forms.Label confirmPasswordLabel;
        private System.Windows.Forms.TextBox m;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button unlock;
        private System.Windows.Forms.TextBox unlockEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button lockEmail;
    }
}

