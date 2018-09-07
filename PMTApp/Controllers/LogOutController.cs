using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMTApp.Controllers
{
    public class LogOutController : Controller
    {
        // GET: LogOut
        public ActionResult Index()
        {
            Session["user"] = null;
            Session["is_logged_in"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}