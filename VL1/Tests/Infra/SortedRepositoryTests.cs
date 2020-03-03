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
            Assert.Inconclusive();
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void setSortingTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void createExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void lambdaExpressionTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void findPropertyTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void getNameTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void setOrderByTest()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void isDescendingTest()
        {
            obj.SortOrder = GetRandom.String();
            Assert.IsFalse(obj.isDescending());
            obj.SortOrder = obj.DescendingString;
            Assert.IsTrue(obj.isDescending());
        }
    }
}
