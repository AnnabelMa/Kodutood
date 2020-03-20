using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Pages.Extensions;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class TableHeaderForHtmlExtensionTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(TableHeaderForHtmlExtension);

        [TestMethod]
        public void TableHeaderForTest()
        {
            Assert.Inconclusive();
        }
    }
}