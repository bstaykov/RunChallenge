using System.Web;
using System.Web.Optimization;

namespace RunChallenge.MVC
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);

            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                "~/Content/kendo/kendo.common.min.css",
                "~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.silver.min.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                "~/Content/site.css",
                "~/Content/bootstrap-responsive.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                "~/Scripts/kendo/kendo.all.min.js",
                "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/kendo/jquery.min.js", 
                "~/Scripts/jquery.unobtrusive-ajax.js"));
            
            // NEVER USED
            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/Scripts/customScript.js"));
        }
    }
}
