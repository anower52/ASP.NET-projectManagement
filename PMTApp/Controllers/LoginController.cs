using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMTRepository;

namespace PMTApp.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["is_logged_in"] != null)
            {
                User_Info u = (User_Info)Session["user"];
                if ( u.UserType == 1)
                {
                return RedirectToAction("Index", "Admin");
                }else if (u.UserType == 2)
                {
                    return RedirectToAction("Index", "ProjectManager");
                }
                else
                {
                    return RedirectToAction("Index", "Developer");
                }
            }
            ViewBag.messege = Session["Error Messeage"];
            Session["Error Messeage"] = "";
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string username = collection["username"];
            string password = collection["password"];

            UserRepository repo = new UserRepository();
            User_Info u = repo.login(username, password);
            if (u !=null)
            {
                Session["user"] = u;
                Session["is_logged_in"] = true;
                if (u.UserType == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if(u.UserType == 2)
                {
                    return RedirectToAction("index", "ProjectManager");
                }
                else
                {
                    return RedirectToAction("index", "Developer");
                }               
            }
            else
            {
                Session["Error Messeage"] = "Invalid username or password";
                return RedirectToAction("Index");
            }
           
        }

    }
}