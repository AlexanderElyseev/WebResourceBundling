using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Hosting;

namespace WebResourceBundling
{
    public class WebResourceVirtualFile : VirtualFile
    {
        private readonly WebResourceData _data;

        public override bool IsDirectory
        {
            get { return false; }
        }

        protected internal WebResourceVirtualFile(string virtualPath, WebResourceData data) : base(virtualPath)
        {
            Contract.Requires<ArgumentNullException>(data != null);
            Contract.Requires<ArgumentException>(data.ResourceAssembly != null);
            Contract.Requires<ArgumentException>(!string.IsNullOrEmpty(data.ResourceName));

            _data = data;
        }

        public override Stream Open()
        {
            return _data.ResourceAssembly.GetManifestResourceStream(_data.ResourceName);
        }
    }
}
