using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Quantity;
using VL1.Domain.Common;
using VL1.Domain.Quantity;

namespace VL1.Tests.Domain.Quantity
{
    [TestClass]
    public class MeasureTermTests: SealedClassTests<MeasureTerm, Entity<MeasureTermData>>
    {
    }
    [TestClass]
    public class SystemOfUnitsTests : SealedClassTests<SystemOfUnits, Entity<SystemOfUnitsData>>
    {
    }
    [TestClass]
    public class UnitFactorTests : SealedClassTests<UnitFactor, Entity<UnitFactorData>>
    {
    }
    [TestClass]
    public class UnitTermTests : SealedClassTests<UnitTerm, Entity<UnitTermData>>
    {
    }
}
