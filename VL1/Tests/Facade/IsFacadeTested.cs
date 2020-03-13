using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests.Facade
{
    [TestClass]
    public class IsFacadeTested: AssemblyTests
    {
        private const string assembly = "VL1.Facade";

        protected override string Namespace(string name){ return $"{assembly}.{name}";}

        [TestMethod] public void IsCommonTested() { IsAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(base.Namespace("Facade")); }
    }
}
