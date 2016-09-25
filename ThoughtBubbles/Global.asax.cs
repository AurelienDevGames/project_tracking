using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ServiceStack.OrmLite;
using ThoughtBubbles.App_Start;
using ThoughtBubbles.Models;

namespace ThoughtBubbles
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            new DBContext();
            //using (var db = DBContext.Factory.Open())
            //{
            //    db.DropAndCreateTable(typeof(Models.Category));
            //    db.DropAndCreateTable(typeof(Models.Question));
            //    db.DropAndCreateTable(typeof(Models.Project));
            //}
        }
    }
}
