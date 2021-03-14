using ManagerProject.Models;
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
        public ActionResult Index()
        {          
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                int res = 0;
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ForgotPassword()
        {
            return PartialView("_ForgotPassword");
        }
    }
}