using System;
using System.Web.Optimization;

namespace WebResourceBundling
{
    public static class WebResourceBundleExtension
    {
        public static Bundle IncludeWebResource(this Bundle bundle, Type assemblyType, string resourceName)
        {
            var provider = WebResourceBundling.WebResourceVirtualPathProvider.CurrentVirtualPathBuilder;
            var data = new WebResourceData
            {
                ResourceAssembly = assemblyType.Assembly,
                ResourceName = resourceName
            };

            return bundle.Include(provider.BuildVirtualPath(data));
        }
    }
}
