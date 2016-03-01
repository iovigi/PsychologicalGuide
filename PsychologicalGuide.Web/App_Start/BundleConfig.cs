using System.Web;
using System.Web.Optimization;

namespace PsychologicalGuide.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/Layout/js").Include(
                       "~/Scripts/jquery-1.11.0.min.js",
                       "~/Scripts/bootstrap.min.js",
                       "~/Scripts/jquery.cookie.js",
                       "~/Scripts/waypoints.min.js",
                       "~/Scripts/jquery.counterup.min.js",
                       "~/Scripts/jquery.parallax-1.1.3.js",
                       "~/Scripts/front.js",
                       "~/Scripts/owl.carousel.min.js",
                       "~/Scripts/respond.js",
                       "~/Scripts/jquery-ui.min.js"));

            /*bundles.Add(new ScriptBundle("~/bundles/Edit/js").Include(
                "~/Scripts/ckeditor/ckeditor.js",
                "~/Scripts/ckeditor/styles.js"));*/

            bundles.Add(new ScriptBundle("~/bundles/Admin/js").Include(
                       "~/Scripts/Admin/jquery.js",
                       "~/Scripts/Admin/jquery-ui-1.10.4.min.js",
                       "~/Scripts/Admin/jquery-1.8.3.min.js",
                       "~/Scripts/Admin/jquery-ui-1.9.2.custom.min.js",
                       "~/Scripts/Admin/bootstrap.min.js",
                       "~/Scripts/Admin/jquery.scrollTo.min.js",
                       "~/Scripts/Admin/jquery.nicescroll.js",
                       "~/Scripts/Admin/assets/jquery-knob/js/jquery.knob.js",
                       "~/Scripts/Admin/jquery.sparkline.js",
                       "~/Scripts/Admin/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.js",
                       "~/Scripts/Admin/owl.carousel.js",
                       "~/Scripts/Admin/fullcalendar.min.js",
                       "~/Scripts/Admin/assets/fullcalendar/fullcalendar/fullcalendar.js",
                       "~/Scripts/Admin/calendar-custom.js",
                       "~/Scripts/Admin/jquery.rateit.min.js",
                       "~/Scripts/Admin/jquery.customSelect.min.js",
                       "~/Scripts/Admin/assets/chart-master/Chart.js",
                       "~/Scripts/Admin/scripts.js",
                       "~/Scripts/Admin/sparkline-chart.js",
                       "~/Scripts/Admin/easy-pie-chart.js",
                       "~/Scripts/Admin/jquery-jvectormap-1.2.2.min.js",
                       "~/Scripts/Admin/jquery-jvectormap-world-mill-en.js",
                       "~/Scripts/Admin/xcharts.min.js",
                       "~/Scripts/Admin/jquery.autosize.min.js",
                       "~/Scripts/Admin/jquery.placeholder.min.js",
                       "~/Scripts/Admin/gdp-data.js",
                       "~/Scripts/Admin/morris.min.js",
                       "~/Scripts/Admin/sparklines.js",
                       "~/Scripts/Admin/charts.js",
                       "~/Scripts/Admin/jquery.slimscroll.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/Layout/css").Include(
                     "~/Content/googleStyle.css",
                     "~/Content/font-awesome.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/custom.css",
                     "~/Content/owl.carousel.css",
                     "~/Content/owl.theme.css",
                     "~/Content/animate",
                     "~/Content/style.default.css",
                     "~/Content/jquery-ui.min.css"));

            bundles.Add(new StyleBundle("~/bundles/Admin/css").Include(
                     "~/Content/Admin/css/bootstrap.min.css",
                     "~/Content/Admin/css/bootstrap-theme.css",
                     "~/Content/Admin/css/elegant-icons-style.css",
                     "~/Content/Admin/css/font-awesome.min.css",
                     "~/Content/Admin/assets/fullcalendar/fullcalendar/bootstrap-fullcalendar.css",
                     "~/Content/Admin/assets/fullcalendar/fullcalendar/fullcalendar.css",
                     "~/Content/Admin/assets/jquery-easy-pie-chart/jquery.easy-pie-chart.css",
                     "~/Content/Admin/css/owl.carousel.css",
                     "~/Content/Admin/css/jquery-jvectormap-1.2.2.css",
                     "~/Content/Admin/css/fullcalendar.css",
                     "~/Content/Admin/css/widgets.css",
                     "~/Content/Admin/css/style.css",
                     "~/Content/Admin/css/style-responsive.css",
                     "~/Content/Admin/css/xcharts.min.css",
                     "~/Content/Admin/css/jquery-ui-1.10.4.min.css"));
        }
    }
}
