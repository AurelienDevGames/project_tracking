using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ThoughtBubbles.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor")
                .Include("~/Scripts/jquery.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/simplemde.min.js"));
            bundles.Add(new StyleBundle("~/bundles/style").IncludeDirectory("~/Content", "*.css"));
            BundleTable.EnableOptimizations = true;

        }
    }
}