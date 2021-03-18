using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerProject.Areas.Admin.Models
{
    public class StatisticModel
    {
        public string category { get; set; }
        public float value { get; set; }
        public string color { get; set; }
    }

    public class StatisticNumberOfSubmissionModel
    {
        public string name { get; set; }
        public int value { get; set; }
    }
}