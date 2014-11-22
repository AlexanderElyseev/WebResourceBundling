using System;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace WebResourceBundling.Example
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            WebResourceVirtualPathProvider.CurrentVirtualPathBuilder = new RawVirtualPathBuilder();
            var virtualPathProvider = new WebResourceVirtualPathProvider();

            BundleTable.VirtualPathProvider = virtualPathProvider;
            BundleTable.EnableOptimizations = false;

            HostingEnvironment.RegisterVirtualPathProvider(virtualPathProvider);
        }
    }
}