using System.Web;
using System.Web.Optimization;

namespace BlnckProyect
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/thirdparty").Include(
                        "~/Assets/ThirdPartyLib/jquery/jquery.min.js",
                        "~/Assets/ThirdPartyLib/bootstrap/propper.min.js",
                        "~/Assets/ThirdPartyLib/bootstrap/bootstrap.min.js",
                        "~/Assets/ThirdPartyLib/bootstrap-select/bootstrap-select.min.js",
                        "~/Assets/ThirdPartyLib/bootstrap-select/defaults-es_ES.min.js",
                        "~/Assets/ThirdPartyLib/alertify/alertify.min.js"));

            bundles.Add(new StyleBundle("~/bundles/themes").Include(
                        "~/Assets/ThirdPartyLib/bootstrap/bootstrap.min.css",
                        "~/Assets/ThirdPartyLib/bootstrap-select/bootstrap-select.min.css",
                        "~/Assets/ThirdPartyLib/datepicker/jquery-ui.min.css",
                        "~/Assets/ThirdPartyLib/alertify/alertify.min.css",
                        "~/Assets/ThirdPartyLib/alertify/default.min.css"
                        ));
        }
    }
}
