﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GET2WORK.Models;
using HeyRed.MarkdownSharp;

namespace GET2WORK.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index", "Home");

            ProjectObjectWrapper ow = new ProjectObjectWrapper();
            using (var db = new MotivationContext())
            {
                ow.Questions = db.Question.Where(x => x.Project.ProjectId == id).ToList();
                ow.Project = db.Project.Find(id);
            }
            Markdown mark = new Markdown();
            ow.Questions.ForEach(x => x.AnswerText = mark.Transform(x.AnswerText));
            return View("Index", ow);
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
                        Project = db.Project.Find(idProject),
                        Date = DateTime.Now
                    });
                    db.SaveChanges();
                }

            return RedirectToAction("Index", "Project", new { id = idProject});
        }

    }

    public class ProjectObjectWrapper
    {
        public List<Question> Questions { get; set; }
        public Project Project { get; set; }
    }

}