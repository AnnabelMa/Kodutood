using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abc.Aids;
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
            string s;
            testCreateExpression(GetMember.Name<MeasureData>(x => x.ValidFrom));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.ValidTo));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Id));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Name));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Code));
            testCreateExpression(GetMember.Name<MeasureData>(x => x.Definition));

            testCreateExpression(s = GetMember.Name<MeasureData>(x => x.ValidFrom), s+obj.DescendingString);
            testCreateExpression(s=GetMember.Name<MeasureData>(x => x.ValidTo), s + obj.DescendingString);
            testCreateExpression(s=GetMember.Name<MeasureData>(x => x.Id), s + obj.DescendingString);
            testCreateExpression(s=GetMember.Name<MeasureData>(x => x.Name), s + obj.DescendingString);
            testCreateExpression(s=GetMember.Name<MeasureData>(x => x.Code), s + obj.DescendingString);
            testCreateExpression(s=GetMember.Name<MeasureData>(x => x.Definition), s + obj.DescendingString);
            testNullExpression(GetRandom.String());
            testNullExpression(string.Empty);
            testNullExpression(null);
        }

        private void testNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNull(lambda);
        }

        private void testCreateExpression(string expected, string name = null)
        {
            name??= expected;//kui name on tühi, võta expected
            obj.SortOrder = name;
            var lambda = obj.createExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<MeasureData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<MeasureData>(x => x.ValidFrom);
            var property = typeof(MeasureData).GetProperty(name);
            var lambda = obj.lambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<MeasureData, object>>));
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
            Expression<Func<MeasureData, object>> expression = measureData => measureData.ToString();
            Assert.IsNull(obj.setOrderBy(null, null));
            IQueryable<MeasureData> data = obj.dbSet;
            Assert.AreEqual(data, obj.setOrderBy(data, null));
            Assert.AreEqual(data, obj.setOrderBy(data, expression));
            var data1 = obj.setOrderBy(data, x => x.Id);
            Assert.AreEqual(data, data1);
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
