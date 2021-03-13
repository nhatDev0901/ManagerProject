using ManagerProject.Models;
using ModelEF.DataAccess;
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

        public ActionResult GetAllPost()
        {
            var list = new PostDataAccess().GetAllPost();
            var res = list.Select(x => new SubmittionModel()
            {
                Sub_ID = x.Sub_ID,
                Sub_Title = x.Sub_Title,
                Department_ID = x.Com_ID,
                Description = x.Sub_Description,
                Created_Date = x.Created_Date.ToString()
            }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}