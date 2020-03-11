using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;

namespace VL1.Tests.Data.Common
{
    [TestClass]
    public class DefinedEntityDataTests : AbstractClassTest<DefinedEntityData, NamedEntityData>
    {
        private class testClass: DefinedEntityData { }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            obj = new testClass();
        }
        [TestMethod]
        public void DefinitionTest()
        {
            IsNullableProperty(() => obj.Definition, x => obj.Definition =x);
        }
    }
}
