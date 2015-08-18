using System.Web.Optimization;

namespace Padaria.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
        
            
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                .Include("~/Scripts/jquery-{version}.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval")
                .Include("~/Scripts/modernizr-{version}.js"));
            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-theme.css"));          
            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
               .Include("~/Scripts/bootstrap.js"));
            bundles.Add(new StyleBundle("~/Content/Custom")
              .Include("~/Content/Custom.css"));
            BundleTable.EnableOptimizations = true;
        }
    }
}