using ManagerProject.Models;
using ModelEF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        private LoginDataAccess dataAccess = new LoginDataAccess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        [HttpPost]
        public ActionResult LoginAdmin(LoginModel model)
        {
            int responseCode = 0;

            var hashPassword = Helper.Commons.MD5Hash(model.Password);
            var result = dataAccess.LoginAdmin(model.UserName, hashPassword);
            if (result == 1) // dang nhap thanh cong
            {
                var userInfo = dataAccess.GetUserInfoLogging(model.UserName);
                var userSession = new UserLoginModel();
                userSession.Username = userInfo.Username;
                userSession.UserID = userInfo.User_ID;
                userSession.Email = userInfo.Email;
                userSession.Department = userInfo.DEPARTMENT.Dep_Name;
                userSession.Role = userInfo.ROLE.Role_Name;
                Session.Add(Helper.Commons.USER_SEESION_ADMIN, userSession);
                responseCode = 1;
            }
            else if (result == -1)
            {
                responseCode = -1;
            }
            else if (result == -3)
            {
                responseCode = -3;
            }
            else if (result == 0)
            {
                responseCode = 0;
            }
            else
            {
                responseCode = -2;
            }
            return Json(responseCode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session[Helper.Commons.USER_SEESION_ADMIN] = null;
            return Redirect("/Admin/");
        }
    }
}