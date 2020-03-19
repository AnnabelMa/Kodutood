using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitViewFactoryTests: BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(UnitViewFactory);
        }
        [TestMethod]
        public void CreateTest() { }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<UnitView>();
            var data = UnitViewFactory.Create(view).Data;

            TestArePropertyValuesEqual(view, data);
        }
        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<UnitData>();
            var view = UnitViewFactory.Create(new Unit(data));

            TestArePropertyValuesEqual(view, data);
        }
    }
}
