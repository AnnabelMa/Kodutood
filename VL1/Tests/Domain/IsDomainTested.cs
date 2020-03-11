using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests.Domain
{
    [TestClass]
    public class IsDomainTested: AssemblyTests
    {
        private const string assembly = "VL1.Domain";

        protected override string Namespace(string name)
        {
            return $"(assembly).{name}";
        }
        [TestMethod] public void IsCommonTested() { isAllTested(assembly, Namespace("Common")); }
        [TestMethod] public void IsQuantityTested() { isAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { isAllTested(base.Namespace("Domain"));}
    }
}
