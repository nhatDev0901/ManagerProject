﻿using ManagerProject.Models;
using ModelEF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Manager.Controllers
{
    public class LoginController : Controller
    {
        // GET: Manager/Login
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
        public ActionResult LoginManager(LoginModel model)
        {
            int responseCode = 0;

            var hashPassword = Helper.Commons.MD5Hash(model.Password);
            var result = dataAccess.LoginManager(model.UserName, hashPassword);
            if (result == 1) // dang nhap thanh cong
            {
                var userInfo = dataAccess.GetUserInfoLogging(model.UserName);
                var userSession = new UserLoginModel();
                userSession.Username = userInfo.Username;
                userSession.UserID = userInfo.User_ID;
                userSession.Email = userInfo.Email;
                userSession.Department = userInfo.DEPARTMENT.Dep_Name;
                userSession.Role = userInfo.ROLE.Role_Name;
                userSession.Department_ID = userInfo.DEPARTMENT.Dep_ID;
                Session.Add(Helper.Commons.USER_SEESION_MANAGER, userSession);
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
            Session[Helper.Commons.USER_SEESION_MANAGER] = null;
            return Redirect("/Manager/");
        }
    }
}