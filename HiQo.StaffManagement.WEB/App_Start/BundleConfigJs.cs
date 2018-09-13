using System.Web;
using System.Web.Optimization;

namespace HiQo.StaffManagement.WEB
{
    public class BundleConfigJs
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/showmap").Include(
                "~/Scripts/ShowMap.js"));

            bundles.Add(new ScriptBundle("~/bundles/bingmap").Include(
                "~/Scripts/BingMap.js"));
        }
    }
}
