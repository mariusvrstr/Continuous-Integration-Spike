
namespace Spike.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.Stubs.Orchestrations;

    [TestClass]
    public class OrchestrationTests
    {
        [TestMethod]
        public void TestUserLoginMustSucceed()
        {
            var username = "UsernameThatWillFail";
            var password = "password";

            var orchestrator = new SecurityOrchestrationStub();
            var response = orchestrator.Login(username, password);

            Assert.IsFalse(response, "A username that contains the word fail must fail");
        }

        [TestMethod]
        public void TestUserLoginMustFail()
        {
            var username = "UsernameThatWillSucceed";
            var password = "password";

            var orchestrator = new SecurityOrchestrationStub();
            var response = orchestrator.Login(username, password);

            Assert.IsTrue(response, "A username that contains does not contain fail must succeed");
        }
    }
}
