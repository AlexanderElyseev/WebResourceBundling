using System.Reflection;

namespace WebResourceBundling
{
    public class RawVirtualPathBuilder : IWebResourceVirtualPathBuilder
    {
        public string BuildVirtualPath(WebResourceData data)
        {
            return "~/WR_" + data.ResourceAssembly.FullName + "_" + data.ResourceName;
        }

        public WebResourceData RestoreFromVirtualPath(string virtualPath)
        {
            if (!virtualPath.StartsWith("~/WR_") && !virtualPath.StartsWith("/WR_"))
                return null;

            var a = virtualPath.Split('_');
            return new WebResourceData { ResourceAssembly = Assembly.Load(a[1]), ResourceName = a[2] };
        }
    }
}