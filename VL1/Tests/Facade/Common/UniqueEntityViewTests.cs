using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Common;

namespace VL1.Tests.Facade.Common
{
    [TestClass]
    public class UniqueEntityViewTests : AbstractClassTests<UniqueEntityView, PeriodView>
    {
        private class testClass : UniqueEntityView { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void IdTest()
        {
            IsNullableProperty(() => obj.Id, x => obj.Id = x);
        }
    }
}
