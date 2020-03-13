using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace VL1.Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTests<UnitData, DefinedEntityData>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            IsNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);
        }
    }
}
