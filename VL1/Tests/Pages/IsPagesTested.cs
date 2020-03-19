using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VL1.Tests.Pages
{
    [TestClass]
    public class IsPagesTested : AssemblyTests
    {
        private const string assembly = "VL1.Pages";

        protected override string Namespace(string name) { return $"{assembly}.{name}"; }

        [TestMethod] public void IsExtensionsTested() { IsAllTested(assembly, Namespace("Extensions")); }
        [TestMethod] public void IsQuantityTested() { IsAllTested(assembly, Namespace("Quantity")); }
        [TestMethod] public void IsTested() { IsAllTested(base.Namespace("Pages")); }
    }
}
