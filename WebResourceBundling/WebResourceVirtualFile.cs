using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Web.Hosting;

namespace WebResourceVirtualPathProvider
{
    internal class WebResourceVirtualFile : VirtualFile
    {
        private readonly Stream _file;

        public override bool IsDirectory
        {
            get { return false; }
        }

        protected internal WebResourceVirtualFile(string virtualPath, Stream file) : base(virtualPath)
        {
            Contract.Requires<ArgumentNullException>(file != null);

            _file = file;
        }

        public override Stream Open()
        {
            return _file;
        }
    }
}
