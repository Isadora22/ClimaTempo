using System.Web.Optimization;

namespace ClimaTempo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                   .Include("~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                   .Include("~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr")
                   .Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
                   .Include("~/Scripts/bootstrap-4.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2")
                   .Include("~/Scripts/select2.min.js"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap-4.3.1.css",                      
                         "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/select2")
                   .Include("~/Content/select2.css"));

            bundles.Add(new ScriptBundle("~/bundles/javascript")
                   .Include("~/Scripts/ClimaTempo.js"));
        }
    }
}
