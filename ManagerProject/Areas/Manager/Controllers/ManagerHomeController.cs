using ICSharpCode.SharpZipLib.Zip;
using ManagerProject.Areas.Admin.Models;
using ManagerProject.Models;
using ModelEF.DataAccess;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Manager.Controllers
{
    public class ManagerHomeController : Controller
    {
        // GET: Manager/ManagerHome
        private StatisticDataAccess dataAccess = new StatisticDataAccess();
        private PostDataAccess DAManager = new PostDataAccess();
        public ActionResult Index()
        {
            if (Session[Helper.Commons.USER_SEESION_MANAGER] == null)
            {
                return Redirect("/Manager/");
            }
            return View();
        }

        public ActionResult DownloadZipFiles(List<int> arrSelect)
        {
            try
            {
                if (System.IO.File.Exists(Server.MapPath("~/Uploads/sample.zip")))
                {
                    System.IO.File.Delete(Server.MapPath("~/Uploads/sample.zip"));
                }

                ZipArchive zip = System.IO.Compression.ZipFile.Open(Server.MapPath("~/Uploads/sample.zip"), ZipArchiveMode.Create);
                foreach (var item in arrSelect)
                {
                    var file = DAManager.GetFilesBySubID(item);
                    foreach (var item2 in file)
                    {
                        if (System.IO.File.Exists(Server.MapPath("~/Uploads/FilesSubmitted/" + item2.File_Path)))
                        {
                            zip.CreateEntryFromFile(Server.MapPath("~/Uploads/FilesSubmitted/" + item2.File_Path), item2.File_Path);
                        }                      
                    }


                }
                zip.Dispose();              
                return File(Server.MapPath("~/Uploads/sample.zip"), "application/zip", "sample.zip");
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public ActionResult Statistic()
        {
            if (Session[Helper.Commons.USER_SEESION_MANAGER] == null)
            {
                return Redirect("/Manager/");
            }
            ViewBag.totalPublic = dataAccess.GetSubmissionPublic(null, "Manager").Count();
            ViewBag.totalNonPublic = dataAccess.GetSubmissionNotPublic(null, "Manager").Count();
            return View();
        }

        public ActionResult GetRateOfSubmissionOrNotSubmissionStatistic()
        {
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_MANAGER];
            var listPublic = dataAccess.GetSubmissionPublic(userInfo.Department_ID, "Manager").Count();
            var listNotPublic = dataAccess.GetSubmissionNotPublic(userInfo.Department_ID, "Manager").Count();
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

        public ActionResult GetNumberOfSubmissionsAll()
        {
            int total;
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION_MANAGER];
            var data = dataAccess.GetSubmissionsInDepartment(userInfo.Department_ID,"Manager", out total);

            var dataModel = new
            {
                Data = data,
                Total = total
            };

            return Json(dataModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubmissionForManager()
        {
            var data = DAManager.GetSubmissionsForManager();
            var res = data.Select(x => new SubmittionModel()
            {
                Sub_ID = x.Sub_ID,
                Sub_Title = x.Sub_Title,
                Department_ID = DAManager.GetDepartmentByUserID(x.USER.User_ID).Dep_ID,
                Department_Name = DAManager.GetDepartmentByUserID(x.USER.User_ID).Dep_Name,
                Description = x.Sub_Description,
                Created_Date = x.Created_Date.ToString(),
                IsPublic = x.IsPublic
            }).ToList();

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeadLine()
        {
            if (Session[Helper.Commons.USER_SEESION_MANAGER] == null)
            {
                return Redirect("/Manager/");
            }
            return View();
        }

        [HttpPost]
        public ActionResult SetDeadLine(DateTime? start, DateTime? end)
        {
            var infoDL = new DEADLINE()
            {
                DeadLine_Start = start,
                DeadLine_End = end,
                Created_Date = DateTime.Now
            };
            var res = DAManager.SetDeadLine(infoDL);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}   