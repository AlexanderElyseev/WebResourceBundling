using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web.Security;

namespace WebResourceBundling
{
    internal class MachineKeyWebResourceVirtualPathBuilder : IWebResourceVirtualPathBuilder
    {
        public string BuildVirtualPath(WebResourceData data)
        {
            var res = data.ResourceAssembly.FullName + ":" + data.ResourceName;

            byte[] bytes = new byte[res.Length * sizeof(char)];
            System.Buffer.BlockCopy(res.ToCharArray(), 0, bytes, 0, bytes.Length);
            var d = MachineKey.Protect(bytes);

            return new SoapHexBinary(d).ToString();
            //
            //            char[] chars = new char[d.Length / sizeof(char)];
            //            System.Buffer.BlockCopy(d, 0, chars, 0, d.Length);
            //            var v = new string(chars);
//
//            StringBuilder hex = new StringBuilder(d.Length * 2);
//            foreach (byte b in d)
//                hex.AppendFormat("{0:x2}", b);
//
//            return hex.ToString();


        }

        public WebResourceData RestoreFromVirtualPath(string virtualPath)
        {
            SoapHexBinary shb = SoapHexBinary.Parse(virtualPath);
            var s = shb.Value;

            var d = MachineKey.Unprotect(s);

            char[] chars = new char[d.Length / sizeof(char)];
            System.Buffer.BlockCopy(d, 0, chars, 0, d.Length);
            var m = new string(chars);

            var a = m.Split(':');

            return new WebResourceData { ResourceAssembly = Assembly.Load(a[0]), ResourceName = a[1] };
        }
    }
}