using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class AbstractClassTest<TClass, TBaseClass> : BaseTest<TClass, TBaseClass>
        //siia ei pane where lauset abstract klassi luua ei saa
    {
        [TestMethod]
        public void IsAbstract()
        {
            Assert.IsTrue(type.IsAbstract);
        }
    }
}