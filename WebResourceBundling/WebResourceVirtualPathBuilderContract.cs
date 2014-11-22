using System;
using System.Diagnostics.Contracts;

namespace WebResourceBundling
{
    [ContractClassFor(typeof(IWebResourceVirtualPathBuilder))]
    internal abstract class WebResourceVirtualPathBuilderContract : IWebResourceVirtualPathBuilder
    {
        string IWebResourceVirtualPathBuilder.BuildVirtualPath(WebResourceData data)
        {
            Contract.Requires<ArgumentNullException>(data != null);
            Contract.Requires<ArgumentException>(data.ResourceAssembly != null);
            Contract.Requires<ArgumentException>(data.ResourceName != null);

            throw new InvalidOperationException();
        }

        WebResourceData IWebResourceVirtualPathBuilder.RestoreFromVirtualPath(string virtualPath)
        {
            Contract.Requires<ArgumentNullException>(virtualPath != null);
            Contract.Requires<ArgumentException>(virtualPath != string.Empty);

            throw new InvalidOperationException();
        }
    }
}