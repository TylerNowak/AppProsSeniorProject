using System;
using System.Collections.Generic;

/// <summary>
/// The UserDashboard Model stores information about the issues retrieved from the Jira Call
/// </summary>
namespace AppAdeptsApp.Models
{
    public class UserDashboard
    {
        public class Issuetype
        {
            public string id { get; set; }
        }

        public class Priority
        {
            public string self { get; set; }
            public string iconUrl { get; set; }
            public string name { get; set; }
            public string id { get; set; }
        }

        public class StatusCategory
        {
            public string self { get; set; }
            public int id { get; set; }
            public string key { get; set; }
            public string colorName { get; set; }
            public string name { get; set; }
        }

        public class Status
        {
            public string Name { get; set; }
        }

        public class Project
        {
            public string id { get; set; }
            public string key { get; set; }
        }

        public class Progress
        {
            public int progress { get; set; }
            public int total { get; set; }
        }

        /// <summary>
        /// Fields breaks down the characteristics of each issue
        /// </summary>
        public class Fields
        {
            public Project project { get; set; }
            public string summary { get; set; }
            public Issuetype issuetype { get; set; }
            public string description { get; set; }
            //public DateTime created { get; set; }
        }

        /// <summary>
        /// Issue contains multiple attributes retrieved from Jira Call
        /// Each issue has a Fields attribute that contains information about the Issue
        /// </summary>
        public class Issue
        {
            public string expand { get; set; }
            public string id { get; set; }
            public string self { get; set; }
            public string key { get; set; }
            public Fields fields { get; set; }

        }

        /// <summary>
        /// Root contains the List of Issues retrieved from the Jira Call
        /// </summary>
        public class Root
        {
            public string expand { get; set; }
            public int startAt { get; set; }
            public int maxResults { get; set; }
            public int total { get; set; }
            public List<Issue> Issues { get; set; }
        }
    }
}

