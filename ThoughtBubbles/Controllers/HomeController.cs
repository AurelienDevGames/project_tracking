using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThoughtBubbles.Models;

namespace ThoughtBubbles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            List<Project> projects;
            using (var db = new MotivationContext())
            {
                projects = db.Project.Include(x => x.Questions).OrderBy(x => x.Name).ToList();
            }

            return View("Index", projects);
        }

        [HttpPost]
        public ActionResult Create(string projectTitle)
        {
            using (var db = new MotivationContext())
            {
                db.Project.Add(new Project() { Name = projectTitle });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}