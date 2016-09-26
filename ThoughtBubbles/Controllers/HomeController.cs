using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.OrmLite;
using ThoughtBubbles.Models;

namespace ThoughtBubbles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Project> projects;
            using (var db = DBContext.Factory.Open())
            {
                projects = db.Select<Project>().ToList();
                DateTime bottomDate = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0, 0)).Date;
                projects.ForEach(x => x.Questions = db.Select<Question>(y => y.ProjectId == x.ProjectId && y.Date >= bottomDate));
            }
            return View("Index", projects);
        }

        [HttpPost]
        public ActionResult Create(string projectTitle)
        {
            using (var db = DBContext.Factory.Open())
            {
                db.Insert(new Project() {Name = projectTitle});
            }
            return RedirectToAction("Index");
        }

    }
}