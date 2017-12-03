using System.Web;
using System.Web.Optimization;

namespace IJMRP
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));




            bundles.Add(new ScriptBundle("~/js/plugins/123").Include(

              //"~/js/bootstrap.min.js",
                //"~/js/plugins/fullcalendar/moment.min.js",
                //"~/js/eonasdan-bootstrap-datetimepicker/build/js/bootstrap-datetimepicker.min.js",
                //"~/js/bootstrap.min.js",
                //<!-- Custom and plugin javascript -->
              "~/js/inspinia.js",
                //"~/js/plugins/pace/pace.min.js",
                //"~/js/plugins/slimscroll/jquery.slimscroll.min.js",
                //<!-- Chosen -->
               "~/js/plugins/chosen/chosen.jquery.js",
                //<!-- JSKnob -->
               "~/js/plugins/jsKnob/jquery.knob.js",
                //<!-- Input Mask-->
                //"~/js/plugins/jasny/jasny-bootstrap.min.js",

                 //<!-- NouSlider -->
                //"~/js/plugins/nouslider/jquery.nouislider.min.js",
                //<!-- Switchery -->
               "~/js/plugins/daterangepicker/daterangepicker.js",
              "~/js/plugins/switchery/switchery.js"
                //<!-- IonRangeSlider -->


              ));


            bundles.Add(new StyleBundle("~/css/plugins/1234").Include(


                "~/css/plugins/sweetalert/sweetalert.css",
                "~/css/plugins/iCheck/custom.css",
                "~/css/plugins/chosen/chosen.css",
                "~/css/plugins/switchery/switchery.css",
                "~/css/plugins/nouslider/jquery.nouislider.css",
                "~/css/plugins/ionRangeSlider/ion.rangeSlider.css",
                "~/css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css",
                "~/css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css",
                "~/css/plugins/daterangepicker/daterangepicker-bs3.css",
              "~/css/plugins/summernote/summernote.css" ,
   "~/css/plugins/summernote/summernote-bs3.css"
                //"~/css/plugins/select2/select2.min.css"
                //"~/css/animate.css",
                //"~/css/style.css"
                ));

        }

        
    }
}