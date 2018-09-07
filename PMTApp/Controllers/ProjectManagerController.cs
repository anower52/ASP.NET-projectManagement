using PMTRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMTApp.Controllers
{
    public class ProjectManagerController : Controller
    {
        // GET: PM
        public ActionResult Index()
        {
            if (Session["is_logged_in"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        ProjectRepository repo = new ProjectRepository();
        UserRepository Urepo = new UserRepository();
        public ActionResult all_project()
        {
            List<AssignToProject> atp = new List<AssignToProject>();
            List<Project_Info> all_project = repo.all_project();
            foreach ( var item in all_project)
            {
                string temp = Urepo.assignToUser(item.Id);
                AssignToProject temp2 = new AssignToProject();
                temp2.ProjectCode = item.CodeName;
                temp2.ProjectName = item.ProjectName;
                temp2.Duration = item.Duration;
                temp2.Status = item.Status;
                temp2.AssignTo = temp;
                temp2.Id = item.Id;
                atp.Add(temp2);
            }
            ViewBag.projectList = atp;
            return View();
        }
        public ActionResult project(int id)
        {
            if (Session["is_logged_in"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View(repo.project(id));
        }
        public ActionResult Details(int id)
        {
            return View(repo.project(id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Project_Info project)
        {
            if (ModelState.IsValid)
            {
                repo.Insert(project);
                return RedirectToAction("all_project", "ProjectManager");
            }
            else
            {
                return View(project);
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(repo.project(id));
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            repo.Delete(id);
            return RedirectToAction("all_project", "ProjectManager");
        }
        public ActionResult Edit(int id)
        {
            return View(repo.project(id));
        }
        [HttpPost]
        public ActionResult Edit(Project_Info project)
        {
            if (ModelState.IsValid)
            {
                repo.Update(project);
                return RedirectToAction("all_project", "ProjectManager");
            }
            else
            {
                return View(project);
            }
        }
        [HttpGet]
        public ActionResult assign_user()
        {
            List<Project_Info> all_project = repo.all_project();
            List<User_Info> all_user = Urepo.all_user();
            all_user = all_user.Where(X => X.UserType != 1).ToList();
            ViewBag.all_project = all_project;
            ViewBag.all_user = all_user;
            return View();
        }
        [HttpPost]
        public ActionResult assign_user(FormCollection collection)
        {

            string projectId = collection["projectId"];
            string userId = collection["userId"];
            int pid = Int32.Parse(projectId);
            int uid = Int32.Parse(userId);
            AssignProjectRepository r = new AssignProjectRepository();
            r.assign_project(pid,uid);
            return RedirectToAction("all_project");
        }

       [HttpGet]
        public ActionResult assign_Task()
        {
            List<Project_Info> all_project = repo.all_project();
            ViewBag.all_project = all_project;
            return View();
        }
        [HttpPost]
        public ActionResult assign_Task(FormCollection collection)
        {
            string projectId = collection["projectId"];
            string userId = collection["userId"];
            string description = collection["description"];
            string due_date = collection["due_date"];
            string priority = collection["priority"];
            Assign_Task at = new Assign_Task();
            at.ProjectId = Int32.Parse(projectId);
            at.RUserId = Int32.Parse(userId);
            at.TaskName = description;
            at.DueDate = DateTime.Parse(due_date);
            at.Priority = projectId;
            User_Info u = (User_Info)Session["user"];
            at.GUserId = u.Id;
            PMTDBContext contex = new PMTDBContext();
            contex.AssignTasks.Add(at);
            contex.SaveChanges();
            return RedirectToAction("View_Task");

        }
        public ActionResult view_Task()
        {
            List<Assign_Task> all_task = repo.all_task();
            List<customTask> ct = new List<customTask>();
            foreach (var item in all_task)
            {
                customTask temp = new customTask();
                string given_user_name = Urepo.user(item.GUserId).Name;
                string recive_user_name = Urepo.user(item.RUserId).Name;
                string project_name = repo.project(item.ProjectId).ProjectName;
                temp.ProjectName = project_name;
                temp.RUserName = recive_user_name;
                temp.GUserName = given_user_name;
                temp.TaskName = item.TaskName;
                temp.DueDate = item.DueDate;
                temp.Priority = item.Priority;
                ct.Add(temp);

            }
            ViewBag.all_task = ct;
            return View();
        }





        public JsonResult userByProject(string id)
        {
            int intid = Int32.Parse(id);
            UserRepository Urepo = new UserRepository();
            List<User_Info> all_user = Urepo.userByproject(intid);
            return Json(all_user, JsonRequestBehavior.AllowGet);
        }


    }
}