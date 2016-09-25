using System;
using System.Collections.Generic;
using System.Data.Entity;
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