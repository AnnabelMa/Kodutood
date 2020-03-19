using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class MeasureViewFactoryTests: BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(MeasureViewFactory);
        }
        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<MeasureView>();
            var data = MeasureViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<MeasureData>();
            var view = MeasureViewFactory.Create(new Measure(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
