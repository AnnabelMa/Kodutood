using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace Tests
{
    //where- lausest edasi: peab olema konstruktor, kus pole argumente
    public abstract class BaseTest<TClass, TBaseClass> where TClass: new()
    {
        [TestMethod]
        public void CanCreateTest()
        {
            Assert.IsNotNull(new TClass());
        }
        [TestMethod]
        public void InheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), new TClass().GetType().BaseType);
        }
    }
}