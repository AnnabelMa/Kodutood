using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Pages.Extensions;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class HypertextLinkForHtmlExtensionTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(HypertextLinkForHtmlExtension);

        [TestMethod]
        public void HypertextLinkForTest()
        {
            Assert.Inconclusive();
        }
    }
}