using System.Collections.Generic;
using System.Web;
using System.Web.Optimization;

namespace CosmeticShop
{
    class BndOrder : IBundleOrderer
    {
        public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
        {
            return files;
        }
    }
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var HomeStyle = new StyleBundle("~/st/HomeIndex")
                 .Include("~/css/bootstrap.css")
                 .Include("~/css/magnific-popup.min.css")
                 .Include("~/css/font-awesome.css")
                 .Include("~/css/jquery.fancybox.min.css")
                 .Include("~/css/themify-icons.css")
                 .Include("~/css/niceselect.css")
                 .Include("~/css/animate.css")
                 .Include("~/css/flex-slider.min.css")
                 .Include("~/css/owl-carousel.css")
                 .Include("~/css/slicknav.min.css")
                 .Include("~/css/reset.css")
                 .Include("~/css/style.css")
                 .Include("~/css/responsive.css");

            var HomeScript = new ScriptBundle("~/sc/HomeIndex")
                .Include("~/js/jquery.min.js")
                .Include("~/js/jquery-migrate-3.0.0.js")
                .Include("~/js/jquery-ui.min.js")
                .Include("~/js/popper.min.js")
                .Include("~/js/bootstrap.min.js")
                .Include("~/js/slicknav.min.js")
                .Include("~/js/owl-carousel.js")
                .Include("~/js/magnific-popup.js")
                .Include("~/js/waypoints.min.js")
                .Include("~/js/finalcountdown.min.js")
                .Include("~/js/nicesellect.js")
                .Include("~/js/flex-slider.js")
                .Include("~/js/scrollup.js")
                .Include("~/js/onepage-nav.min.js")
                .Include("~/js/easing.js")
                .Include("~/js/active.js");

            HomeStyle.Orderer = new BndOrder();
            HomeScript.Orderer = new BndOrder();
            bundles.Add(HomeStyle);
            bundles.Add(HomeScript);
        }
    }
}
