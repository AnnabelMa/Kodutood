using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Quantity;
using VL1.Pages.Extensions;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class DisplayControlsForHtmlExtensionTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(DisplayControlsForHtmlExtensions);

        [TestMethod]
        public void DisplayControlsForTest()
        {
            var obj = new htmlHelperMock<UnitView>().DisplayControlsFor(x => x.MeasureId);
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            var expected = new List<string> { "<dt", "DisplayNameFor", "</dt>", "<dd", "DisplayFor", "</dd>" };
            var actual = 
                DisplayControlsForHtmlExtensions.HtmlStrings(new htmlHelperMock<MeasureView>(), x => x.ValidFrom);
            TestHtml.Strings(actual, expected);
        }
    }
}
