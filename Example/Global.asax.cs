using System;
using System.Web.Optimization;

namespace WebResourceBundling
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleTable.VirtualPathProvider = new WebResourceVirtualPathProvider.WebResourceVirtualPathProvider();
            BundleTable.EnableOptimizations = true;
        }
    }
}