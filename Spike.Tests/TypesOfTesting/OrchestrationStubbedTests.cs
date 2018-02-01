
namespace Spike.Tests.TypesOfTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.Contracts;
    using Spike.SDK;

    [TestClass]
    public class OrchestrationStubbedTests : BaseTestClass
    {
        public OrchestrationStubbedTests() : base(ResolveBy.Default) {}

        ISecurityOrchestration securityOrchestration { get; set; }

        [TestMethod]
        public void TestUserLoginMustSucceed()
        {
            var username = "UsernameThatWillFail";
            var password = "password";

            var orchestrator = UnityFactory.Resolve<ISecurityOrchestration>();
            var response = orchestrator.Login(username, password);

            Assert.IsFalse(response, "A username that contains the word fail must fail");
        }

        [TestMethod]
        public void TestUserLoginMustFail()
        {
            var username = "UsernameThatWillSucceed";
            var password = "password";

            var orchestrator = UnityFactory.Resolve<ISecurityOrchestration>();
            var response = orchestrator.Login(username, password);

            Assert.IsTrue(response, "A username that contains does not contain fail must succeed");
        }
    }
}
