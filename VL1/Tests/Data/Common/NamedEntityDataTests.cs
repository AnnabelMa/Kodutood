using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;

namespace Tests.Data.Common
{
    [TestClass]
    public class NamedEntityDataTests : AbstractClassTest<NamedEntityData, UniqueEntityData>
    {
        private class testClass : NamedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
    }
}
