using System.Web.Optimization;

namespace HiQo.StaffManagement.WEB
{
    public class BundleConfigCss
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/Content/Styles/css").Include(
                "~/Content/body.css"));
        }
    }
}