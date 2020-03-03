using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests
{
    //where- lausest edasi: peab olema konstruktor, kus pole argumente
    public abstract class SealedClassTest<TClass, TBaseClass> : ClassTest<TClass, TBaseClass> where TClass: new()
    {
        [TestMethod]
        public void IsSealed()
        {
            Assert.IsTrue(type.IsSealed);
        }
    }
}