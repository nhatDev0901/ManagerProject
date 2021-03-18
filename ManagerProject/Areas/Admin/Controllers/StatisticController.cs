using ManagerProject.Areas.Admin.Models;
using ManagerProject.Models;
using ModelEF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Admin.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Admin/Statistic
        private StatisticDataAccess dataAccess = new StatisticDataAccess();
        public ActionResult Index()
        {
            if (Session[Helper.Commons.USER_SEESION_ADMIN] == null)
            {
                return Redirect("/Admin/");
            }

            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            ViewBag.totalPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Admin").Count();
            ViewBag.totalNonPublic = dataAccess.GetSubmissionNotPublic(userInfo.Department_ID, "Admin").Count();

            return View();
        }

        public ActionResult GetRateOfSubmissionOrNotSubmissionStatistic()
        {
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var listPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Admin").Count();
            var listNotPublic = dataAccess.GetSubmissionNotPublic(userInfo.Department_ID, "Admin").Count();
            int total = listPublic + listNotPublic;
            float ratePublic = (listPublic * 100) / total;
            float rateNotPublic = (listNotPublic * 100) / total;

            var dataModel = new List<StatisticModel>();
            dataModel.Add(new StatisticModel
            {
                category = "Public",   
                value = ratePublic,
                color = "#90cc38"
            });

            dataModel.Add(new StatisticModel
            {
                category = "Not public",               
                value = rateNotPublic,
                color = "#cb3414"
            });
            return Json(dataModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNumberOfSubmissionsInDepartment()
        {
            int total;
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var data = dataAccess.GetSubmissionsInDepartment(userInfo.Department_ID, "Admin",out total);

            var dataModel = new
            {
                Data = data,
                Total = total
            };

            return Json(dataModel, JsonRequestBehavior.AllowGet);
        }
    }
}