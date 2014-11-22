using System;
using System.Web.Optimization;
using System.Web.UI;

namespace WebResourceBundling.Example
{
    class C { }

    public partial class WebForm1 : Page
    {
        protected string S1
        {
            get { return ClientScript.GetWebResourceUrl(typeof(C), "WebResourceBundling.Example.JavaScript1.js"); }
        }

        protected string S2
        {
            get { return ClientScript.GetWebResourceUrl(typeof(C), "WebResourceBundling.Example.JavaScript2.js"); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var bundle = new ScriptBundle("~/bundle");
            bundle.IncludeWebResource(typeof(C), "WebResourceBundling.Example.JavaScript1.js");
            bundle.IncludeWebResource(typeof(C), "WebResourceBundling.Example.JavaScript2.js");
            BundleTable.Bundles.Add(bundle);

            s1.Attributes["href"] = S1;
            s2.Attributes["href"] = S2;
            s3.Attributes["href"] = Scripts.Url("~/bundle").ToString();
        }
    }
}