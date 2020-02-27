using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VL1.Aids;

namespace Tests
{
    public abstract class BaseTest<TClass, TBaseClass>
    {
        protected TClass obj;
        protected Type type;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);
        }
        [TestMethod]
        public void InheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), type.BaseType);
        }

        //Meetodi sisu:
        //kui on get, set ja rnd funktsioon, siis võtan d, võtan get funktsiooni, 
        //kontrollin, et ei annaks tulemust; panen setiga d õigesse kohta, 
        //saan kontrollida, kas on sama väärtus
        protected static void isNullableProperty<T>(Func<T> get, Action<T> set) //where T: Nullable
        {
            var d = (T) GetRandom.Value(typeof(T));
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
            //set(null);
            //Assert.IsNull(get());
        }
    }
}