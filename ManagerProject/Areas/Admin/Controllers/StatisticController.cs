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
            var totalPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Admin").Count();
            var totalnonPublic = dataAccess.GetSubmissionNotPublic(userInfo.Department_ID, "Admin").Count();
            ViewBag.totalPublic = totalPublic;
            ViewBag.totalNonPublic = totalnonPublic;

            return View();
        }

        public ActionResult GetRateOfSubmissionOrNotSubmissionStatistic()
        {
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var listPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Admin").Count();
            var listNotPublic = dataAccess.GetSubmissionNotPublic(userInfo.Department_ID, "Admin").Count();
            int total = listPublic + listNotPublic;
            float ratePublic, rateNotPublic;
            if (total <= 0)
            {
                ratePublic = 0;
                rateNotPublic = 0;
            }
            else
            {
                ratePublic = (listPublic * 100) / total;
                rateNotPublic = (listNotPublic * 100) / total;
            }
             

            var dataModel = new List<StatisticModel>();
            if (total > 0)
            {
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
            }
            
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

        public ActionResult GetTopStudentHaveMostPublicSubmission()
        {
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_ADMIN];
            var listPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Admin");

            var studentInDep = dataAccess.GetUsersByDep(userInfo.Department_ID);
            List<ChartDataViewmodel> dataChart = new List<ChartDataViewmodel>();
            foreach (var item in studentInDep)
            {
                ChartDataViewmodel a = new ChartDataViewmodel();
                a.value = item.Username;
                a.num = listPublic.Where(x => x.USER.User_ID == item.User_ID).Count();
                dataChart.Add(a);
            }
            return Json(dataChart, JsonRequestBehavior.AllowGet);
        }
    }
}