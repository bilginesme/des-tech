using System.Web;
using System.Web.Optimization;

namespace DesTech
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/all.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js",
                        "~/Scripts/bootstrap.min.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/jquery.magnific-popup.min.js",
                        "~/Scripts/wow.min.js",
                        "~/Scripts/isotope.pkgd.min.js",
                        "~/Scripts/imagesloaded.pkgd.min.js",
                        "~/Scripts/smoothscroll.js",
                        "~/Scripts/jquery.easing.min.js",
                        "~/Scripts/jquery.mb.YTPlayer.min.js",
                        "~/Scripts/owl.carousel.min.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/custom.js",
                        "~/Scripts/theme.js"
                        ));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/animate.min.css",
                "~/Content/magnific-popup.css",
                "~/Content/jquery.mb.YTPlayer.min.css",
                "~/Content/owl.carousel.min.css",
                "~/Content/owl.theme.default.css",
                "~/Content/custom.css",
                "~/Content/theme.css",
                "~/Content/helper.css"
                ));
        }
    }
}
