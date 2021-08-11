using System.Web;
using System.Web.Optimization;

namespace AppWebHojaCosto
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/js").Include(
                      "~/Scripts/menu-admin.js",
                      "~/Scripts/notificacion-admin.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery-1.12.4.js",
                      "~/Scripts/jquery-ui.js",
                      "~/Scripts/jquery.easing.min.js",
                      //"~/Scripts/Chart.bundle.min.js",
                      "~/Scripts/Chart.min.js",
                      "~/Scripts/jquery.dataTables.js",
                      "~/Scripts/dataTables.bootstrap4.js",
                      "~/Scripts/sb-admin.min.js",
                      "~/Scripts/sb-admin-datatables.min.js",
                      //"~/Scripts/bootstrap-checkbox.js",
                      "~/Scripts/jquery.toast.js",
                      //"~/Scripts/jquery-1.12.4.js",
                      //"~/Scripts/jquery-ui.js",
                      "~/Scripts/jquery.validate.js",
                      "~/Scripts/jQuery.Ajax.Unobtrusive.js",
                      "~/Scripts/jquery.unobtrusive-ajax.js",
                      //"~/Scripts/chartist.min.js",
                      //"~/Scripts/d3.v3.min.js",
                      //"~/Scripts/c3.js",
                      "~/Scripts/JavaScript.js",
                      "~/Scripts/raphael-2.1.4.min.js",
                      "~/Scripts/justgage.js",
                      "~/Scripts/jquery.dm-uploader.min.js",
                      "~/Scripts/js-sinc-ref.js",
                      "~/Scripts/jquery-confirm.min.js",
                      "~/Scripts/print.min.js",
                      "~/Scripts/loader.js",
                      "~/Scripts/dataTables.checkboxes.min.js"
                      /*"~/Scripts/sb-admin-charts.min.js"*/));

            bundles.Add(new ScriptBundle("~/Scripts/jsLogin").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.bundle.min.js",
                      "~/Scripts/jquery.easing.min.js",
                      "~/Scripts/jquery.toast.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/jquery.dm-uploader.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/dataTables.bootstrap4.css",
                      "~/Content/sb-admin.css",
                      "~/Content/StyleSheet.css",
                      "~/Content/jquery.toast.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/chartist.min.css",
                      "~/Content/c3.css",
                      "~/Content/bootstrap-theme.min.css",
                      "~/Content/jquery-confirm.min.css",
                      "~/Content/print.min.css",
                      "~/Content/dataTables.checkboxes.css"));
        }
    }
}