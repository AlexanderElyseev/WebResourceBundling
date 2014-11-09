using System;
using System.Web.Optimization;
using WebResourceVirtualPathProvider;

namespace WebResourceBundling
{
    class C { }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected string S1
        {
            get { return ClientScript.GetWebResourceUrl(typeof(C), "WebResourceBundling.JavaScript1.js"); }
        }
        protected string S2
        {
            get { return ClientScript.GetWebResourceUrl(typeof(C), "WebResourceBundling.JavaScript2.js"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            s1.Attributes["href"] = S1;
            s2.Attributes["href"] = S2;

            var bundle = new ScriptBundle("~/bundle");
            bundle.IncludeWebResource(typeof (C), "WebResourceBundling.JavaScript1.js");
            bundle.IncludeWebResource(typeof (C), "WebResourceBundling.JavaScript2.js");
            
            BundleTable.Bundles.Add(bundle);
        }
    }
}