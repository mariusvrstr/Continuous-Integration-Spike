
namespace Spike.Tests.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.SDK;

    /// <summary>
    /// These unit tests have no dependancies
    /// </summary>
    [TestClass]
    public class BasicUnitTests
    {       
        [TestMethod]
        public void Basic_TestSha256HashMustSucceed()
        {
            const string randomText = "SomeRandomText";
            const string expectedRandomHash = "f69804e5a135035020b5c1fdec659fafc6947350a462dca9731e4f14db2e9120";   

            var hashValue = HashWorker.GenerateSha256(randomText);

            Assert.AreEqual(expectedRandomHash, hashValue, "Generated hash value did not match as expected");
        }
    }
}
