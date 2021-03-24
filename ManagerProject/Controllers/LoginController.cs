using ManagerProject.Models;
using ModelEF.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Controllers
{
    public class LoginController : Controller
    {
        /*private MyContext db = new MyContext();
        // GET: Loginform
        public ActionResult Loginform()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Loginform(User user)
        {
            var result = db.Users.Where(k => k.Username == user.Username && k.Password == user.Password).FirstOrDefault();
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Auth");

            }
            else
            {
                ModelState.AddModelError("", "Invalid Username or Password");
                return View();
            }
        }*/
        // GET: Login
        private LoginDataAccess dataAccess = new LoginDataAccess();
        public ActionResult Index()
        {          
            return View();
        }

        public ActionResult LoginGuest() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            int responseCode = 0;

            var hashPassword = Helper.Commons.MD5Hash(model.Password);
            var result = dataAccess.LoginHome(model.UserName, hashPassword);

            if (result == 1) // dang nhap thanh cong
            {
                var userInfo = dataAccess.GetUserInfoLogging(model.UserName);
                var userSession = new UserLoginModel();
                userSession.Username = userInfo.Username;
                userSession.UserID = userInfo.User_ID;
                userSession.Email = userInfo.Email;
                userSession.Department = userInfo.DEPARTMENT.Dep_Name;
                userSession.Role = userInfo.ROLE.Role_Name;
                userSession.RoleID = userInfo.ROLE.Role_ID;
                userSession.Department_ID = userInfo.DEPARTMENT.Dep_ID;
                Session.Add(Helper.Commons.USER_SEESION, userSession);
                //return RedirectToAction("Index", "Home");
                responseCode = 1;
            }
            else if (result == -1)
            {
                //ModelState.AddModelError("", "Username / Password is not correct");
                responseCode = -1;
            }
            else if (result == -3)
            {
                //ModelState.AddModelError("", "Account dose not access to page. Not permission.");
                responseCode = -3;
            }
            else if (result == 0)
            {
                //ModelState.AddModelError("", "Account not exists!");
                responseCode = 0;
            }
            else
            {
                //ModelState.AddModelError("", "Loggin not success! System error.");
                responseCode = -2;
            }
            return Json(responseCode, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }

        public ActionResult Logout()
        {
            Session[Helper.Commons.USER_SEESION] = null;
            return Redirect("/");
        }

        public ActionResult ChooseRole()
        {
            return View();
        }
    }
}