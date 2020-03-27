using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass>
        //siia ei pane where lauset, abstract klassi luua ei saa
    {
        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);
        }
    }
}