using System.Collections.Generic;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Facade.Quantity;
using VL1.Pages.Extensions;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class WebPageTitleForHtmlExtensionTests : BaseTests
    {
        [TestInitialize] public virtual void TestInitialize() => type = typeof(WebPageTitleForHtmlExtension);

            [TestMethod]
            public void WebPageTitleForTest()
            {
                var obj = new htmlHelperMock<UnitView>().WebPageTitleFor(GetRandom.String());
                Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
            }

            [TestMethod]
            public void HtmlStringsTest()
            {
                var expected = new List<string> { "<h1>", GetRandom.String(), "</h1>" };
                var actual = WebPageTitleForHtmlExtension.htmlStrings(expected[1]);
                TestHtml.Strings(actual, expected);
            }
        }
    }
