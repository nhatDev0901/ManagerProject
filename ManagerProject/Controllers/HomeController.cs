using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.Message = "Your application descrjhbjhbhjbhjiptiodsdsdsdsdn jljljjpage.";
            ViewBag.Message = "DuongTrN";

            //hello tao nè

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page. Như Khánh đã vào!";
            ViewBag.Message = "Đcm da đen";
            return View();
        }
    }
}