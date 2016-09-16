using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GET2WORK.Models;

namespace GET2WORK.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string date)
        {
            DateTime timestamp = DateTime.Now;
            if (!string.IsNullOrWhiteSpace(date))
                timestamp = DateTime.Parse(date);
            HomeWrapper wrapper = new HomeWrapper();
            using (var db = new MotivationContext())
            {
                wrapper.Projects = db.Project.ToList();
                wrapper.Motivation = db.Motivation.SingleOrDefault(x => x.Timestamp == timestamp);
            }

            return View("Index", wrapper);
        }

        [HttpPost]
        public ActionResult Create(string projectTitle)
        {
            using (var db = new MotivationContext())
            {
                db.Project.Add(new Project() {Name = projectTitle });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }

    public class HomeWrapper
    {
        public List<Project> Projects { get; set; }
        public Motivation Motivation { get; set; }
    }

}