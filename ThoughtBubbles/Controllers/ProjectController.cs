using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HeyRed.MarkdownSharp;
using ServiceStack.OrmLite;
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

            Project project;
            using (var db = DBContext.Factory.Open())
            {
                project = db.SingleById<Project>(id.Value);
                project.Questions = db.Select<Question>(x => x.ProjectId == id.Value);
            }
            Markdown mark = new Markdown();
            project.Questions.ForEach(x => x.AnswerText = mark.Transform(x.AnswerText));
            return View("Index", project);
        }

        [HttpPost]
        public ActionResult CreateQa(string q, string a, int idProject)
        {
            if (!string.IsNullOrWhiteSpace(q) || !string.IsNullOrWhiteSpace(a))
                using (var db = DBContext.Factory.Open())
                {
                    db.Insert(new Question()
                    {
                        QuestionText = q,
                        AnswerText = a,
                        Date = DateTime.Now,
                        ProjectId = idProject
                    });
                }

            return RedirectToAction("Index", "Project", new { id = idProject });
        }

        [HttpPost]
        public ActionResult DeleteQa(int idQuestion, int idProject)
        {
            if (idQuestion != 0)
                using (var db = DBContext.Factory.Open())
                {
                    db.DeleteById<Question>(idQuestion);
                }
            return RedirectToAction("Index", "Project", new { id = idProject });
        }

    }
}