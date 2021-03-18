using ICSharpCode.SharpZipLib.Zip;
using ManagerProject.Areas.Admin.Models;
using ManagerProject.Models;
using ModelEF.DataAccess;
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
        public ActionResult Index()
        {
            if (Session[Helper.Commons.USER_SEESION_MANAGER] == null)
            {
                return Redirect("/Manager/");
            }
            return View();
        }

        public FileResult DownloadZipFiles()
        {
            string fileName = string.Format("{0}_Files.zip", DateTime.Today.Date.ToString("dd-MM-yyyy") + "_1");
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Uploads/"));
            //var tempOutPutPaht = Server.MapPath(Url.Content("/Uploads/")) + fileName; 

            try
            {
                //using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                //{
                //    zip.AlternateEncodingUsage = Ionic.Zip.ZipOption.AsNecessary;
                //    zip.AddDirectoryByName("Uploads");
                //    var listFile = new List<string>();
                //    listFile.Add(Server.MapPath("~/Uploads/Research_Ethics_Approval_Form.docx"));
                //    listFile.Add(Server.MapPath("~/Uploads/Research_Proposal_Form.docx"));

                //    foreach (var item in filePaths)
                //    {
                //        zip.AddFile(item, "Uploads");
                //    }
                //    string zipName = String.Format("Zip_{0}.zip", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss"));
                //    using (MemoryStream ms = new MemoryStream())
                //    {
                //        zip.Save(ms);
                //        return File(filePaths[0], "application/zip", zipName);]p
                //    }
                //}

                Response.Clear();
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "filename=" + "sample.zip");
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
                {
                    zip.AddDirectory(Server.MapPath("~/Uploads"));
                    zip.Save(Server.MapPath("~/Uploads/sample.zip"));
                    byte[] byte1 = System.IO.File.ReadAllBytes(Server.MapPath("~/Uploads/sample.zip"));
                    return File(byte1 , "application/zip", "sample.zip");
                }
            }
            catch (Exception e)
            {

                throw;
            }
          

            

            //return File(finalResult, "application/zip", fileName);
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
    }
}   