using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YouTrackAPI.Models
{
    public class Issue
    {
        public string Max { get; set; }
        public string State { get; set; }
        public string Brand { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Prio { get; set; }
        public string Estimated { get; set; }
    }
}