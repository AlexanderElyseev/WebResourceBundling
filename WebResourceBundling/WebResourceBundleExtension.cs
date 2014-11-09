using System;
using System.Web.Optimization;

namespace WebResourceVirtualPathProvider
{
    public static class WebResourceBundleExtension
    {
        public static Bundle IncludeWebResource(this Bundle bundle, Type assemblyType, string resourceName)
        {
            var virtualPath = string.Format(
                WebResourceVirtualPathProvider.UrlTemplate,
                assemblyType.AssemblyQualifiedName,
                resourceName);

            return bundle.Include(virtualPath);
        }
    }
}
