using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagerProject.Areas.Manager
{
    public class ManagerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Manager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Manager_default",
                "Manager/{controller}/{action}/{id}",
                new { action = "Index", Controller = "Login", id = UrlParameter.Optional },
                new[] { "ManagerProject.Areas.Manager.Controllers" }
            );
        }
    }
}