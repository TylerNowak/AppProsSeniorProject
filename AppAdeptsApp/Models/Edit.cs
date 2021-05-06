using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// The Edit Model allows access to user input data as well as the retrieved IssueID from Issue cards on the Dashboard
/// </summary>
namespace AppAdeptsApp.Models
{
    public class Edit
    {
        public UserDashboard.Issue editIssue { get; set; }
        public string IssueId { get; set; }
        public IFormFile AttachmentField { get; set; }
        public string EditText { get; set; }
    }


}
