using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Chat Model allows access to the User input and attachments for the Chat Controller
/// Chat contains messages that are displayed for the specific User
/// </summary>
namespace AppAdeptsApp.Models
{
    public class Chat
    {
        public class Messages
        {
            public string[] messages { get; set; }

            [Required(ErrorMessage = "Please enter a message. We don't see anything here! 😱")]
            public string TextField { get; set; }
            public string SummaryField { get; set; }
            public string TitleField { get; set; }
            public string ReturnUrl { get; set; }
            
            public bool IsChatHidden { get; set; }
            public bool IsIssueHidden { get; set; }
            public IFormFile AttachmentField { get; set; }
        }
    }
}
