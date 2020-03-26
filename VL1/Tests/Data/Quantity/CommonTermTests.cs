using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace VL1.Tests.Data.Quantity
{
    [TestClass]
    public class CommonTermTests: AbstractClassTests<CommonTermData, PeriodData>
    {
        private class testClass: CommonTermData { }

        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void MasterIdTest()
        {
            IsNullableProperty(() => obj.MasterId, x=> obj.MasterId=x);
        }

        //[TestMethod]
        //public void TermIdTest()
        //{
        //    IsNullableProperty(() => obj.TermId, x => obj.TermId = x);
        //}
    }
}
