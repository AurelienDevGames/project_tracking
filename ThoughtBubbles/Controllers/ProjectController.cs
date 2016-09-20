using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeyRed.MarkdownSharp;
using ThoughtBubbles.Models;

namespace ThoughtBubbles.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Home");

            Project Project;
            using (var db = new MotivationContext())
            {
                Project = db.Project.Include(x => x.Questions).First(x => x.ProjectId == id);
            }
            Markdown mark = new Markdown();
            Project.Questions.ForEach(x => x.AnswerText = mark.Transform(x.AnswerText));
            return View("Index", Project);
        }

        [HttpPost]
        public ActionResult CreateQA(string q, string a, int idProject)
        {
            if (!string.IsNullOrWhiteSpace(q) || !string.IsNullOrWhiteSpace(a))
                using (var db = new MotivationContext())
                {
                    db.Question.Add(new Question()
                    {
                        QuestionText = q,
                        AnswerText = a,
                        Date = DateTime.Now,
                        ProjectId = idProject
                    });
                    db.SaveChanges();
                }

            return RedirectToAction("Index", "Project", new { id = idProject });
        }

    }
}