using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAdeptsApp.Models
{
    public class Submit
    {
        public string SummaryField { get; set; }
        public string DescriptionField { get; set; }
        public IFormFile AttachmentField { get; set; }
    }
}
