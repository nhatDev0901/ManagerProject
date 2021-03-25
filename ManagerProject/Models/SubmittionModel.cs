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
        public int? IsPublic { get; set; } 
        public string PublicStatus
        {
            get
            {
                string text = "Not Public";
                if (IsPublic == 1)
                {
                    text = "Public";
                }
                return text;
            }
        }
    }

    public class ParamInputCreateModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public List<HttpPostedFileBase> files { get; set; }
        public int Sub_ID { get; set; }
        public string SubCode { get; set; }
    }

    public class ChangeStatusSubmissionModel
    {
        public int Sub_ID { get; set; }
    }

    public class ItemValueModel
    {
        public int ItemValue { get; set; }
        public string ItemText { get; set; }
    }

    public class ListSubIDModel
    {
        public List<int> ListSubID { get; set; } 
    }

    public class DeadLineViewModel
    {
        public string DeadLine_Content { get; set; }
        public string DeadLine_start { get; set; }
        public string DeadLine_end { get; set; }
    }

    public class ChartDataViewmodel
    {
        public int num { get; set; }
        public string value { get; set; }
    }

    public class CommentViewModel
    {
        public int CommentID { get; set; }
        public string CommentContent { get; set; }
        public int? UserID { get; set; }
        public string Username { get; set; }
        public int? SubID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    }
}