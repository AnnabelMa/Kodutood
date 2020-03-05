﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VL1.Data.Common;
using VL1.Data.Quantity;

namespace VL1.Tests.Data.Quantity
{
    [TestClass]
    public class UnitDataTests : SealedClassTest<UnitData, DefinedEntityData>
    {
        [TestMethod]
        public void MeasureIdTest()
        {
            isNullableProperty(() => obj.MeasureId, x => obj.MeasureId = x);
        }
    }
}