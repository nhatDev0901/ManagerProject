using ICSharpCode.SharpZipLib.Zip;
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
        public ActionResult Index()
        {
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
    }
}   