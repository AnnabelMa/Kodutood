using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace Tests
{
    //where- lausest edasi: peab olema konstruktor, kus pole argumente
    public abstract class SealedClassTest<TClass, TBaseClass> : ClassTest<TClass, TBaseClass> where TClass: new()
    {
        [TestMethod]
        public void IsSealed()
        {
            Assert.IsTrue(type.GetType().IsSealed);
        }
    }
}