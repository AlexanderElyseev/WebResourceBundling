using System.Diagnostics.Contracts;

namespace WebResourceBundling
{
    [ContractClass(typeof(WebResourceVirtualPathBuilderContract))]
    public interface IWebResourceVirtualPathBuilder
    {
        string BuildVirtualPath(WebResourceData data);

        WebResourceData RestoreFromVirtualPath(string virtualPath);
    }
}
