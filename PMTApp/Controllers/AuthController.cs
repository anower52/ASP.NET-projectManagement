using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMTApp.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Change_password()
        {
            
            ViewBag.messege = Session["Error Messeage"];
            Session["Error Messeage"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Change_password(FormCollection collection)
        {
            string pass = collection["newPass"];
            string repass = collection["reNewPass"];
            if(pass == repass)
            {

            }
            else{
                Session["Error Messeage"] = "Password doesnt match";
                return RedirectToAction("Change_password");
            }
            return View();
        }
    }
}