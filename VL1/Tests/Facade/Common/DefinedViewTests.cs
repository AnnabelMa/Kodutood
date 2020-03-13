using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Common;

namespace VL1.Tests.Facade.Common
{
    [TestClass]
    public class DefinedViewTests : AbstractClassTests<DefinedView, NamedView>
    {
        private class testClass: DefinedView { }

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
