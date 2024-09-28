using System.Web;
using System.Web.Optimization;

namespace Doantieuluanlaptrinh
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/js/jquery.min.js",
                       "~/Scripts/js/bootstrap.bundle.min.js",
                       "~/Scripts/js/jquery.hoverIntent.min.js",
                       "~/Scripts/js/jquery.waypoints.min.js",
                       "~/Scripts/js/superfish.min.js",
                       "~/Scripts/js/owl.carousel.min.js",
                       "~/Scripts/js/jquery.plugin.min.js",
                       "~/Scripts/js/jquery.magnific-popup.min.js",
                       "~/Scripts/js/jquery.countdown.min.js",
                       "~/Scripts/js/main.js",
                       "~/Scripts/js/demos/demo-2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/css/bootstrap.min.css",
                      "~/Content/css/plugins/owl-carousel/owl.carousel.css",
                      "~/Content/css/plugins/magnific-popup/magnific-popup.css",
                      "~/Content/css/plugins/jquery.countdown.css",
                      "~/Content/css/style.css",
                      "~/Content/css/skins/skin-demo-2.css",
                      "~/Content/css/demos/demo-2.css",
                      "~/Scripts/jquery-{version}.js"));
        }
    }
}
