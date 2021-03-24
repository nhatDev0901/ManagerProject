using ManagerProject.Areas.Admin.Models;
using ManagerProject.Models;
using ModelEF.DataAccess;
using ModelEF.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
//using System.IO;
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
        private StatisticDataAccess StatisticDA = new StatisticDataAccess();
        public ActionResult Index()
        {
            if (Session[Helper.Commons.USER_SEESION] == null)
            {
                return Redirect("/");
            }
            //check deadline
            DateTime now = DateTime.Now;
            int checkDeadline = 0;
            var deadLineAvailable = dataAccess.GetDeadLine();
            if (now >= deadLineAvailable.DeadLine_Start && now <= deadLineAvailable.DeadLine_End)
            {
                checkDeadline = 1;
            }
            else
            {
                checkDeadline = 2;
            }
            ViewBag.CheckDeadLine = checkDeadline;
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
            int resCode = 0;
            try
            {
                var newSubmitID = dataAccess.CreateIDAuto("SM");
                //var userInfo = dataAccess.GetUserInfoByID(2); 
                var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION];
                param.description = HttpUtility.HtmlDecode(RemoveHtmlTag(HttpUtility.HtmlDecode(param.description).Replace("<br />", "\n").Replace("</li>", "\n").Replace("&nbsp;", "")));
                // lưu submittion
                var inforSubmit = new SUBMITTION()
                {
                    Sub_Title = param.title,
                    Sub_Description = param.description,
                    Created_Date = DateTime.Now,
                    Sub_Code = newSubmitID,
                    Created_By = userInfo.UserID,
                    IsPublic = 0
                };
                var newID = dataAccess.AddSubmits(inforSubmit);               
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
                            files.Sub_ID = newID;
                            // lưu file vào folder
                            item.SaveAs(path + fileName);
                            var insertFile = dataAccess.InsertFile(files);

                        }
                    }
                }
                Task.Run(() => Helper.SendMail.SendEmailWhenAddNewSubmittion(userInfo.UserID.ToString(), userInfo.Username, userInfo.Department, userInfo.Email, param.title, param.files.Count()));

                resCode = 1;
            }
            catch (Exception)
            {
                resCode = -1;
                throw;
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
            var userInfor = (UserLoginModel)Session[Helper.Commons.USER_SEESION];
            var subInfor = dataAccess.GetSubmittionByID(param.Sub_ID);
            param.description = HttpUtility.HtmlDecode(RemoveHtmlTag(HttpUtility.HtmlDecode(param.description).Replace("<br />", "\n").Replace("</li>", "\n").Replace("&nbsp;", "")));  
            var inforSubmit = new SUBMITTION()
            {
                Sub_ID = param.Sub_ID,
                Sub_Title = param.title,
                Sub_Description = param.description,
                Updated_Date = DateTime.Now,
                Updated_By = userInfor.UserID
            };
            res = dataAccess.EditSubmission(inforSubmit);
            var listOwnFile = dataAccess.GetFilesBySubCode(param.SubCode);

            if (param.files.Count() > 0)  // if student has file change
            {
                // xoa file cũ trong Folder va DB
                var rootFolder = Server.MapPath("~/Uploads/FilesSubmitted/");
                foreach (var item in listOwnFile)
                {
                    if (System.IO.File.Exists(Path.Combine(rootFolder, item.File_Path)))
                    {
                        System.IO.File.Delete(Path.Combine(rootFolder, item.File_Path));
                    }

                    var delete = dataAccess.DeleteFile(item.File_ID);
                }
                // edit file in DbContext and save new file
                foreach (var item in param.files)
                {
                    var newFile = new FILE();
                    string filename = string.Format("{0}_{1}_{2}{3}", userInfor.Username, param.SubCode, DateTime.Now.Ticks.ToString(), System.IO.Path.GetExtension(item.FileName));

                    newFile.Sub_ID = param.Sub_ID;
                    newFile.Sub_Code = param.SubCode;
                    newFile.File_Name = item.FileName;
                    newFile.File_Path = filename;

                    item.SaveAs(rootFolder + filename);
                    res = dataAccess.InsertFile(newFile);
                }
            }

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteContribution(int Subid, string title)
        {
            ViewBag.SubID = Subid;
            ViewBag.Title = title;
            return PartialView("_DeleteContribution");
        }

        public ActionResult DeleteSubmission(int id)
        {
            var listOwnFile = dataAccess.GetFilesBySubID(id);
            if (listOwnFile.Count() > 0)
            {
                var rootFolder = Server.MapPath("~/Uploads/FilesSubmitted/");
                foreach (var item in listOwnFile)
                {
                    if (System.IO.File.Exists(Path.Combine(rootFolder, item.File_Path)))
                    {
                        System.IO.File.Delete(Path.Combine(rootFolder, item.File_Path));
                    }
                }
            }
            var res = dataAccess.DeleteSubmission(id);
               
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetAllPostOfStudent()
        {
            //var userInfo = dataAccess.GetUserInfoByID(2);
            var userInfo = (UserLoginModel)Session[Helper.Commons.USER_SEESION];
            var list = new PostDataAccess().GetAllPostByUser(userInfo.UserID); // hard code
            var res = list.Select(x => new SubmittionModel()
            {
                Sub_ID = x.Sub_ID,
                Sub_Title = x.Sub_Title,
                Department_ID = userInfo.Department_ID,
                Department_Name = userInfo.Department,
                Description = x.Sub_Description,
                Created_Date = x.Created_Date.ToString()
            }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public static string RemoveHtmlTag(string content)
        {
            if (string.IsNullOrEmpty(content))
                return content;
            else
            {
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<[^>]+\s*?>", " ");
                return content.Trim();
            }
        }

        public ActionResult GetListDepartment()
        {
            var item = new List<ItemValueModel>();
            var res = dataAccess.GetListDepartment();
            item = res.Select(x => new ItemValueModel {
                ItemText = x.Dep_Name,
                ItemValue = x.Dep_ID
            }).ToList();
            return Json(item, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetListSubmissionsByDepartment(int? DepID)
        {
            var data = dataAccess.GetListSubmisstionForAdmin(DepID);
            var currentDep = dataAccess.GetListDepartment().Where(x => x.Dep_ID == DepID).FirstOrDefault();
            var res = data.Select(x => new SubmittionModel()
            {
                Sub_ID = x.Sub_ID,
                Sub_Title = x.Sub_Title,
                Department_ID = currentDep.Dep_ID,
                Department_Name = currentDep.Dep_Name,
                Description = x.Sub_Description,
                IsPublic = x.IsPublic,
                Created_Date = x.Created_Date.ToString()
            }).ToList();
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StatisticForGuest()
        {
            if (Session[Helper.Commons.USER_SEESION] == null)
            {
                return Redirect("/");
            }
            return View();
        }

        public ActionResult GetRateOfSubmissionOrNotSubmissionStatistic(int? DepID)
        {
            
            var listPublic = StatisticDA.GetSubmissionPublic(DepID, "Guest").Count();
            var listNotPublic = StatisticDA.GetSubmissionNotPublic(DepID, "Guest").Count();
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
    }
}