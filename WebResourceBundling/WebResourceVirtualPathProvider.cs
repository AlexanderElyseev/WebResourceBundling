using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace WebResourceVirtualPathProvider
{
    public class WebResourceVirtualPathProvider : VirtualPathProvider
    {
        internal static string UrlTemplate
        {
            get { return "~/WRVPP.axd?t={0}&r={1}"; }
        }

        public override bool FileExists(string virtualPath)
        {
            return base.FileExists(virtualPath) || GetWebResourceStream(virtualPath) != null;
        }

        public override VirtualFile GetFile(string virtualPath)
        {
            var stream = GetWebResourceStream(virtualPath);
            if (stream == null)
                throw new ArgumentException();

            return new WebResourceVirtualFile(virtualPath, stream);
        }

        public static Stream GetWebResourceStream(string virtualPath)
        {
            if (virtualPath == null || !virtualPath.StartsWith("~/WRVPP.axd?"))
                return null;

            var queryParams = HttpUtility.ParseQueryString(virtualPath.Split('?')[1]);
            var typeName = queryParams["t"];
            var resourceName = queryParams["r"];

            if (string.IsNullOrEmpty(typeName) || string.IsNullOrEmpty(resourceName))
                return null;
            
            var assemblyType = Type.GetType(typeName);
            if (assemblyType == null)
                return null;

            return assemblyType.Assembly.GetManifestResourceStream(resourceName);
        }
    }
}
