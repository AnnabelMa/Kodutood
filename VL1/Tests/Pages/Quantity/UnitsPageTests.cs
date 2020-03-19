using System.Linq;
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
    public class UnitsPageTests : AbstractClassTests<UnitsPage,
        BasePage<IUnitsRepository, Unit, UnitView, UnitData>>
    {
        private class testClass : UnitsPage
        {
            internal testClass(IUnitsRepository r, IMeasuresRepository m) : base(r, m)
            {
            }
        }
        private class unitsRepository : baseTestRepository<Unit, UnitData>, IUnitsRepository { }
        private class measuresRepository : baseTestRepository<Measure, MeasureData>, IMeasuresRepository { }

        private unitsRepository units;
        private measuresRepository measures;
        private MeasureData data;

        [TestInitialize]
        public override void TestInitialize() 
        {
            base.TestInitialize();
            units = new unitsRepository(); 
            measures = new measuresRepository();
            data = GetRandom.Object<MeasureData>();
            var m = new Measure(data);
            measures.Add(m).GetAwaiter();
            AddRandomMeasures();
            obj = new testClass(units, measures);
        }

        private void AddRandomMeasures()
        {
            for (var i = 0; i < GetRandom.UInt8(3, 10); i++)
            {
                var d = GetRandom.Object<MeasureData>();
                var m = new Measure(d);
                measures.Add(m).GetAwaiter();
            }
        }

        [TestMethod]
        public void ItemIdTest()
        {
            var item = GetRandom.Object<UnitView>();
            obj.Item = item;
            Assert.AreEqual(item.Id, obj.ItemId);
            obj.Item = null;
            Assert.AreEqual(string.Empty, obj.ItemId);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Units", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Quantity/Units", obj.PageUrl);

        [TestMethod]
        public void ToObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public void ToViewTest()
        {
            var d = GetRandom.Object<UnitData>();
            var view = obj.ToView(new Unit(d));
            TestArePropertyValuesEqual(view, d);
        }
        [TestMethod]
        public void GetMeasureNameTest()
        {
            var name = obj.GetMeasureName(data.Id);
            Assert.AreEqual(data.Name, name);
        }
        [TestMethod]
        public void MeasuresTest()
        {
            var list = measures.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Measures.Count());
        }
    }
}
