using VL1.Pages.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests.Pages.Extensions
{
    [TestClass]
    public class EditControlsForEnumHtmlExtensionTests : BaseTests
    {
        //private class testClass : NamedView
        //{
        //    public IsoGender Gender { get; set; }
        //}

        [TestInitialize] public virtual void TestInitialize() => type = typeof(EditControlsForEnumHtmlExtension);

        [TestMethod]
        public void EditControlsForEnumTest()
        {
            Assert.Inconclusive();
            //var obj = new htmlHelperMock<testClass>().EditControlsForEnum(x => x.Gender);
            //Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod]
        public void HtmlStringsTest()
        {
            Assert.Inconclusive();
            //var selectList = new SelectList(Enum.GetNames(typeof(IsoGender)));
            //var expected = new List<string> { "<div", "LabelFor", "DropDownListFor", "ValidationMessageFor", "</div>" };
            //var actual = EditControlsForEnumHtmlExtension.htmlStrings(new htmlHelperMock<testClass>(),
            //    x => x.Gender, selectList);
            //TestHtml.Strings(actual, expected);
        }
    }
}