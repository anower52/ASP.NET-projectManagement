//using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PMTRepository;

namespace PMTApp.Controllers
{
    public class AdminController : Controller
    {
      
        // GET: Admin
        public ActionResult Index()
        {
            if (Session["is_logged_in"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        UserRepository repo = new UserRepository();
        public ActionResult all_user()
        {
            if (Session["is_logged_in"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(repo.all_user());
        }
        public ActionResult user(int id)
        {
            if (Session["is_logged_in"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(repo.user(id));
        }
        public ActionResult Details(int Id)
        {
            return View(repo.user(Id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User_Info user)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(user);
                return RedirectToAction("all_user", "Admin");
            }
            else
            {
                return View(user);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.user(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            repo.Delete(id);
            return RedirectToAction("all_user","Admin");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(repo.user(id));
        }
        [HttpPost]
        public ActionResult Edit(User_Info user)
        {
            if(ModelState.IsValid)
            {
                repo.Update(user);
                return RedirectToAction("all_user" , "Admin");
            }
            else
            {
                return View(user);
            }
        }

        public JsonResult AutoComplete(string term)
        {
            PMTDBContext context = new PMTDBContext();
            List<string> user_name = new List<string>();
            List<User_Info> clist = context.UserInfo.Where(c => c.Name.Contains(term)).ToList();
            foreach (var c in clist)
            {
                user_name.Add(c.Name);
            }

            return Json(user_name, JsonRequestBehavior.AllowGet);
        }
    }
}