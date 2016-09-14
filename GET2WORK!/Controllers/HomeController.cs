using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GET2WORK_.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string date)
        {
            if (string.IsNullOrWhiteSpace(date))
                date = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";

            return View();
        }
    }
}