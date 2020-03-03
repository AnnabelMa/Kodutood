using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace VL1.Tests.Data.Quantity
{
    [TestClass]
    public class UnitFactorDataTest : SealedClassTest<UnitFactorData, PeriodData>
    {
        [TestMethod]
        public void FactorTest()
        {
            isProperty(() => obj.Factor, x => obj.Factor = x);
        }
        [TestMethod]
        public void SystemOfUnitsIdTest()
        {
            isNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);
        }
        [TestMethod]
        public void UnitIdTest()
        {
            isNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        }
    }
}
