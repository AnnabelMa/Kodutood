using System;
using Abc.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests
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
            isProperty(get, set);
            set(default); //ehk d = default(T); set(d)
            Assert.IsNull(get());
        }

        protected static void isProperty<T>(Func<T> get, Action<T> set) //kontrollib, kas saan võtta juhusliku värtuse ja sellega testida
        {
            var d = (T)GetRandom.Value(typeof(T));
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }
        protected static void isReadOnlyProperty(object o, string name, object expected)
        {//kui objekt on olemas, objekti järgi saan nime ja property.
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            var actual = property.GetValue(o);
            Assert.AreEqual(expected, actual);
        }
    }
}