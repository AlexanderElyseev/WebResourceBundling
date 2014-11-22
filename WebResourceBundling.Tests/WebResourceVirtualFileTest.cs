using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebResourceBundling.Tests
{
    [TestClass]
    public class WebResourceVirtualFileTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLoadingResourcesWithNullAssembly()
        {
            var data = new WebResourceData
            {
                ResourceAssembly = null,
                ResourceName = "WebResourceBundling.Tests.Resource.txt"
            };

            new WebResourceVirtualFile("path", data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLoadingResourcesWithNullResourceName()
        {
            var data = new WebResourceData
            {
                ResourceAssembly = Assembly.GetExecutingAssembly(),
                ResourceName = null
            };

            new WebResourceVirtualFile("path", data);
        }

        [TestMethod]
        public void TestLoadingResources()
        {
            var data = new WebResourceData
            {
                ResourceAssembly = Assembly.GetExecutingAssembly(),
                ResourceName = "WebResourceBundling.Tests.Resource.txt"
            };
            var file = new WebResourceVirtualFile("path", data);
            var stream = file.Open();

            Assert.IsNotNull(stream);
            Assert.AreEqual("Content", new StreamReader(stream).ReadToEnd());
        }
    }
}
