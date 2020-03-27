using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Facade.Common;
using VL1.Facade.Quantity;

namespace VL1.Tests.Facade.Quantity
{
    [TestClass]
    public class UnitViewTests: SealedClassTests<UnitView, DefinedView>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            IsNullableProperty( () => obj.MeasureId, x => obj.MeasureId=x);
        }
    }
}
