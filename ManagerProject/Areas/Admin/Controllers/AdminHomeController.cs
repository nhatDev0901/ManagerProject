using ManagerProject.Models;
using ModelEF.DataAccess;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        private PostDataAccess dataAccess = new PostDataAccess();
        public ActionResult Index()
        {
            if (Session[Helper.Commons.USER_SEESION_ADMIN] == null)
            {
                return Redirect("/Admin/");
            }
            return View();
        }

        public ActionResult GetSubmissionForAdmin()
        {
            try
            {
                var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
                var listData = dataAccess.GetListSubmisstionForAdmin(userInfo.Department_ID);
                var res = listData.Select(x => new SubmittionModel()
                {
                    Sub_ID = x.Sub_ID,
                    Sub_Title = x.Sub_Title,
                    Department_ID = userInfo.Department_ID,
                    Department_Name = userInfo.Department,
                    Description = x.Sub_Description,
                    Created_Date = x.Created_Date.ToString(),
                    IsPublic = x.IsPublic
                }).ToList();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new List<SubmittionModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditContribution(int Subid)
        {
            var data = dataAccess.GetSubmittionByID(Subid);
            var model = new SubmittionModel()
            {
                Sub_ID = data.Sub_ID,
                Sub_Title = data.Sub_Title,
                Description = data.Sub_Description,
                SubCode = data.Sub_Code
            };
            ViewBag.SubmissionInfo = model;
            return PartialView("_EditContribution");
        }

        public ActionResult EditSubmission(ParamInputCreateModel param)
        {
            int res = 0;
            var userInfor = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var inforSubmit = new SUBMITTION()
            {
                Sub_ID = param.Sub_ID,
                Sub_Title = param.title,
                Sub_Description = param.description,
                Updated_Date = DateTime.Now,
                Updated_By = userInfor.UserID
            };
            res = dataAccess.EditSubmission(inforSubmit);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteContribution()
        {
            return PartialView("_DeleteContribution");
        }

        [HttpPost]
        public ActionResult PublicFiles(List<int> listSubmiss)
        {
            var model = new SUBMITTION();
            int resCode = 0;
            foreach (var item in listSubmiss)
            {
                model.Sub_ID = item;
                model.IsPublic = 1;
                var resDB = dataAccess.EditPublicStatus(model);
            }
            
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Comment(int SubID)
        {
            ViewBag.SubID = SubID;
            var submission = dataAccess.GetSubmittionByID(SubID);

            ViewBag.TitleSub = submission.Sub_Title;
            ViewBag.Description = submission.Sub_Description;
            ViewBag.CreatedDate = submission.Created_Date.Value.ToString("dd/MM/yyyy");
            ViewBag.CreatedBy = submission.USER.Username;

            var comments = dataAccess.GetListCommentBySubID(SubID);
            var model = comments.Select(x => new CommentViewModel()
            {
                CommentID = x.Com_ID,
                CommentContent = x.Com_Name,
                UserID = x.User_ID,
                Username = x.USER.Username,
                SubID = x.Sub_ID,
                CreatedBy = x.Created_By,
                CreatedDate = x.Created_Date
            }).OrderByDescending(x => x.CreatedDate).ToList();
            return View(model);
        }

        public ActionResult AddComment(int SubID, string Comment)
        {
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var newComment = new COMMENT()
            {
                Com_Name = Comment,
                User_ID = userInfo.UserID,
                Sub_ID = SubID,
                Created_Date = DateTime.Now,
                Created_By = userInfo.Username
            };
            var res = dataAccess.AddComment(newComment);

            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}