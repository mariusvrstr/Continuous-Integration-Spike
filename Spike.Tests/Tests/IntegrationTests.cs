
namespace Spike.Tests.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.Contracts;
    using Spike.Tests.Builders;

    [TestClass]
    public class IntegrationTests : TransactionBase
    {
        ISecurityOrchestration securityOrchestration { get; set; }

        [TestMethod]
        public void Integration_TestUserLoginMustSucceed()
        {
            var builder = new UserEntityBuilder().John();

            var orchestrator = OrchestrationFactory.CreateSecurityOrchestration(false, false);
            var response = orchestrator.Login(builder.Username, builder.Password);

            Assert.IsTrue(response, "The password is wrong");
        }

        [TestMethod]
        public void integration_TestUserLoginMustFail()
        {
            var builder = new UserEntityBuilder().John();

            var orchestrator = OrchestrationFactory.CreateSecurityOrchestration(false, false);
            var response = orchestrator.Login(builder.Username, "Wrong password");

            Assert.IsFalse(response, "The password is wrong");
        }
    }
}
