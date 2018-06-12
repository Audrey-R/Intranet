using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Diagnostics;

namespace Intranet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception objErr = Server.GetLastError().GetBaseException();
        //    string err = "Error Caught in Application_Error event\n" +
        //    "Error in: " + Request.Url.ToString() +
        //    "\nError Message:" + objErr.Message.ToString() +
        //    "\nStack Trace:" + objErr.StackTrace.ToString();
        //    EventLog.WriteEntry("Sample_WebApp", err, EventLogEntryType.Error);
        //    //Server.ClearError();
        //    //additional actions...
        //}
    }
}
