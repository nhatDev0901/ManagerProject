using ManagerProject.Models;
using ModelEF.DataAccess;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Controllers
{
    public class HomeController : Controller
    {
        private PostDataAccess dataAccess = new PostDataAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application descrjhbjhbhjbhjiptdddiodsdsdsdsdn jljljjpage.";
            ViewBag.Message = "DuongTrN";
            ViewBag.Message = "tao ne/ doan xem ai, dcm";

            //hello tao nè

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page. Như Khánh đã vào!";
            return View();
        }

        public ActionResult AddContribution()
        {
            return PartialView("_AddNew");
        }

        public ActionResult AddSubmittion(ParamInputCreateModel param)
        {
            var newSubmitID = dataAccess.CreateIDAuto("SM");
            var userInfo = dataAccess.GetUserInfoByID(2); // muc dich lay thong tin user đang đăng nhập
            int resCode;
            // lưu submittion
            var inforSubmit = new SUBMITTION()
            {
                Sub_Title = param.title,
                Sub_Description = param.description,
                Created_Date = DateTime.Now,
                Sub_Code = newSubmitID,
                Created_By = userInfo.User_ID
            };
            resCode = dataAccess.AddSubmits(inforSubmit);

            // lưu file của submitton
            if (param.files.Count() > 0)
            {
                string path = Server.MapPath("~/Uploads/FilesSubmitted/");
                foreach (var item in param.files)
                {
                    if (item != null)
                    {
                        var files = new FILE();
                        string fileName = string.Format("{0}_{1}_{2}{3}", userInfo.Username, newSubmitID, DateTime.Now.Ticks.ToString(), System.IO.Path.GetExtension(item.FileName));

                        files.File_Name = item.FileName;
                        files.File_Path = fileName;
                        files.Sub_Code = newSubmitID;

                        // lưu file vào folder
                        
                        item.SaveAs(path + fileName);
                        resCode = dataAccess.InsertFile(files);

                    }
                }
            }
            
            return Json(resCode, JsonRequestBehavior.AllowGet);
        }
        public async Task<ActionResult> EmailNotification()
        {          
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var fromEmail = "nguyw461@gmail.com";
                var username = ConfigurationManager.AppSettings["USER_NAME"].ToString();
                var password = ConfigurationManager.AppSettings["PASSWORD"].ToString(); 
                var toEmail = ConfigurationManager.AppSettings["TO_EMAIL"].ToString();

                var message = new MailMessage();
                message.To.Add(new MailAddress(toEmail));
                message.From = new MailAddress(fromEmail);
                message.Subject = "NEW CONTRIBUTION FROM STUDENT: DUCNHAT";
                message.Body = string.Format(body, "nhat", "nhat", "nhat");
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())                                                     
                {
                    smtp.Host = ConfigurationManager.AppSettings["HOST"].ToString();
                    smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["PORT"].ToString());
                    smtp.Credentials = new NetworkCredential(username, password);
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(message);
                }
                

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
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

        public ActionResult GetAllPostOfStudent()
        {
            var userInfo = dataAccess.GetUserInfoByID(2);
            var list = new PostDataAccess().GetAllPostByUser(2); // hard code
            var res = list.Select(x => new SubmittionModel()
            {
                Sub_ID = x.Sub_ID,
                Sub_Title = x.Sub_Title,
                Department_ID = userInfo.DEPARTMENT.Dep_ID,
                Department_Name = userInfo.DEPARTMENT.Dep_Name,
                Description = x.Sub_Description,
                Created_Date = x.Created_Date.ToString()
            }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}