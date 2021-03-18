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
                }).AsEnumerable();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new List<SubmittionModel>(), JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditContribution()
        {
            return PartialView("_EditContribution");
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
    }
}