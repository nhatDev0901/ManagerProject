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
        public string Department_Name { get; set; }
        public string Description { get; set; } 
        public string Created_Date { get; set; } 
        public string SubCode { get; set; } 
    }

    public class ParamInputCreateModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<HttpPostedFileBase> files { get; set; }
        public int Sub_ID { get; set; }
        public string SubCode { get; set; }
    }
}