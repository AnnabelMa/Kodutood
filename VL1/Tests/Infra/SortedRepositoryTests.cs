using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abc.Aids;
using Antlr.Runtime.Misc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Quantity;
using VL1.Domain.Quantity;
using VL1.Infra;
using VL1.Infra.Quantity;

namespace VL1.Tests.Infra
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTest<SortedRepository<Measure, MeasureData>,
        BaseRepository<Measure, MeasureData>>
    {
        private class testClass : SortedRepository<Measure, MeasureData>
        {
            public testClass(DbContext c, DbSet<MeasureData> s) : base(c, s)
            {
            }

            protected override Task<MeasureData> getData(string id)
            {
                throw new System.NotImplementedException();
            } 
        }
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var c = new QuantityDbContext(new DbContextOptions<QuantityDbContext>());
            obj = new testClass(c, c.Measures);
        }

        [TestMethod]
        public void SortOrderTest()
        { 
            isNullableProperty(()=>obj.SortOrder, x=> obj.SortOrder=x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<testClass>(x => x.DescendingString);
            isReadOnlyProperty(obj, propertyName, "_desc");
        }
        [TestMethod]
        public void SetSortingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = obj.lambdaExpression(property);
            Assert.IsNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Antlr.Runtime.Misc.Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.findProperty());
            }
            test(null, GetRandom.String());
            test(null, null);
            test(null, string.Empty);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)), s);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Name)),
                s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidFrom)),
                s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.ValidTo)),
                s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Definition)),
                s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Code)),
                s + obj.DescendingString);
            test(typeof(MeasureData).GetProperty(s = GetMember.Name<MeasureData>(x => x.Id)),
                s + obj.DescendingString);
        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;
            void test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.getName());
            }
            test(s=GetRandom.String(), s);
            test(s=GetRandom.String(), s+obj.DescendingString);
            test(string.Empty, string.Empty);
            test(string.Empty, null);
        }
        [TestMethod]
        public void SetOrderByTest()
        {
            Assert.Inconclusive();
        }
        [TestMethod]
        public void IsDescendingTest()
        {
            void test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                var actual = obj.isDescending();
                Assert.AreEqual(expected, actual);
            }
            test(GetRandom.String(), false);
            test(GetRandom.String() + obj.DescendingString, true);
            test(string.Empty, false);
            test(null, false);
        }
    }
}
