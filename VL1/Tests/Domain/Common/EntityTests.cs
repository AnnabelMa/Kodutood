using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;
using VL1.Data.Quantity;
using VL1.Domain.Common;

namespace VL1.Tests.Domain.Common
{
    [TestClass]
    public class EntityTests: AbstractClassTests<Entity<MeasureData>, object>
    {
        private class testClass : Entity<MeasureData>
        {
            public testClass(MeasureData d=null) : base(d)
            {
            }
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }

        [TestMethod]
        public void DataTest()
        {
            var d = GetRandom.Object<MeasureData>();
            Assert.AreNotSame(d, obj.Data);
            obj = new testClass(d);
            Assert.AreSame(d, obj.Data);
        }

        [TestMethod]
        public void DataIsNullTest()
        {
            var d = GetRandom.Object<MeasureData>();
            Assert.IsNotNull(obj.Data);
            obj.Data = d;
            Assert.AreSame(d, obj.Data);
        }

        [TestMethod]
        public void CanSetNullDataTest()
        {
            var d = GetRandom.Object<MeasureData>();
            obj = new testClass(d);
            Assert.IsNotNull(obj.Data);
            obj.Data = null;
            Assert.IsNull(obj.Data);
        }
    }
}
