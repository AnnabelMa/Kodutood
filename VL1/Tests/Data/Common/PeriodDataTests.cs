using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VL1.Data.Common;

namespace Tests.Data.Common
{
    [TestClass]
    public class PeriodDataTests : AbstractClassTest<PeriodData, object>
    {
        private class testClass : PeriodData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void ValidFromTest()
        {
            isNullableProperty(() => obj.ValidFrom, x => obj.ValidFrom =x, () => DateTime.Now);
        }
        [TestMethod]
        public void ValidToTest()
        {
            isNullableProperty(() => obj.ValidTo, x => obj.ValidTo = x, () => DateTime.Now);
        }
    }
}
