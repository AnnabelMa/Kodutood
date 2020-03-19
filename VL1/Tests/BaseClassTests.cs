using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Aids;

namespace VL1.Tests
{
    public abstract class BaseClassTests<TClass, TBaseClass>: BaseTests
    {
        protected TClass obj;

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
        protected static void IsNullableProperty<T>(Func<T> get, Action<T> set) //where T: Nullable
        {
            IsProperty(get, set);
            set(default); //ehk d = default(T); set(d)
            Assert.IsNull(get());
        }

        protected static void IsProperty<T>(Func<T> get, Action<T> set) //kontrollib, kas saan võtta juhusliku värtuse ja sellega testida
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