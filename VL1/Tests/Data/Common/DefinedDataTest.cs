using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VL1.Data.Common;

namespace Tests.Data.Common
{
    [TestClass]
    public class DefinedDataTest : AbstractClassTest<DefinedEntityData, NamedEntityData>
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
            isNullableProperty(() => obj.Definition, x => obj.Definition =x);
        }
    }
}
