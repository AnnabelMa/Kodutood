using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;

namespace Tests.Data.Common
{
    [TestClass]
    public class UniqueEntityDataTests : AbstractClassTest<UniqueEntityData, PeriodData>
    {
        private class testClass : UniqueEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
    }
}
