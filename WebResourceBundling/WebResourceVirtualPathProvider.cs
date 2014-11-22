using System;
using System.Collections;
using System.Web.Caching;
using System.Web.Hosting;

namespace WebResourceBundling
{
    public class WebResourceVirtualPathProvider : VirtualPathProvider
    {
        public static IWebResourceVirtualPathBuilder CurrentVirtualPathBuilder { get; set; }

        public override bool FileExists(string virtualPath)
        {
            var data = CurrentVirtualPathBuilder.RestoreFromVirtualPath(virtualPath);

            return data != null || base.FileExists(virtualPath);
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var data = CurrentVirtualPathBuilder.RestoreFromVirtualPath(virtualPath);
            if (data != null)
                return new WebResourceVirtualFile(virtualPath, data);

            return base.GetFile(virtualPath);
        }

        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart)
        {
            return null;
        }
    }
}
