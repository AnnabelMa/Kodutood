using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace VL1.Tests.Data.Quantity
{
    [TestClass]
    public class UnitFactorDataTests : SealedClassTests<UnitFactorData, PeriodData>
    {
        [TestMethod]
        public void FactorTest()
        {
            IsProperty(() => obj.Factor, x => obj.Factor = x);
        }
        [TestMethod]
        public void SystemOfUnitsIdTest()
        {
            IsNullableProperty(() => obj.SystemOfUnitsId, x => obj.SystemOfUnitsId = x);
        }
        [TestMethod]
        public void UnitIdTest()
        {
            IsNullableProperty(() => obj.UnitId, x => obj.UnitId = x);
        }
    }
}
