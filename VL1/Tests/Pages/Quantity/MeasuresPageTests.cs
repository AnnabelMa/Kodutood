using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;
using VL1.Pages;
using VL1.Pages.Quantity;

namespace VL1.Tests.Pages.Quantity
{
    [TestClass]
    public class MeasuresPageTests : AbstractClassTests<MeasuresPage,
        BasePage<IMeasuresRepository, Measure, MeasureView, MeasureData>>
    {
        private class testClass : MeasuresPage
        {
            internal testClass(IMeasuresRepository r) : base(r)
            {
            }
        }

        private class testRepository : baseTestRepository<Measure, MeasureData>, IMeasuresRepository
        {

        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var r = new testRepository();
            obj = new testClass(r);
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<MeasureView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Measures", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Quantity/Measures", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<MeasureView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var data = GetRandom.Object<MeasureData>();
            var view = obj.ToView(new Measure(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
 