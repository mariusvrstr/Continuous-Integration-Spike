﻿
namespace Spike.Tests.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Spike.Contracts;
    using Spike.SDK;

    [TestClass]
    public class StubbedUnitTests
    {
        ISecurityOrchestration securityOrchestration { get; set; }

        [TestMethod]
        public void Stubbed_TestUserLoginMustSucceed()
        {
            var username = "UsernameThatWillFail";
            var password = "password";

            var orchestrator = OrchestrationFactory.CreateSecurityOrchestration(true, false);
            var response = orchestrator.Login(username, password);

            Assert.IsFalse(response, "A username that contains the word fail must fail");
        }

        [TestMethod]
        public void Stubbed_TestUserLoginMustFail()
        {
            var username = "UsernameThatWillSucceed";
            var password = "password";

            var orchestrator = OrchestrationFactory.CreateSecurityOrchestration(true, false);
            var response = orchestrator.Login(username, password);

            Assert.IsTrue(response, "A username that contains does not contain fail must succeed");
        }
    }
}
