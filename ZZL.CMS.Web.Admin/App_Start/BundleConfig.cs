using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace ZZL.CMS.Web.Admin.App_Start
{
    public class BundleConfig
    {
        public static void BundleRegister(BundleCollection collection)
        {
            collection.Add(new ScriptBundle("~/Scripts/Jquery").Include("~/Scripts/jquery-{version}.js", "~/Scripts/migrate.js"));

            collection.Add(new ScriptBundle("~/Scripts/Jquery.easy.ui").Include(
                "~/Scripts/jquery.easyui.min.1.2.2.js",
                "~/Content/js/outlook2.js"
                ));

            collection.Add(new StyleBundle("~/Content/Default").Include(
                "~/Content/css/default.css",
                "~/Content/js/themes/default/easyui.css",
                "~/Contentjs/themes/icon.css"
                ));




        }
    }
}