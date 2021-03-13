using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerProject.Models
{
    public class SubmittionModel
    {
        public int Sub_ID { get; set; }
        public string Sub_Title { get; set; }
        public int? Department_ID { get; set; }
        public string Description { get; set; } 
        public DateTime? Created_Date { get; set; } 
    }
}