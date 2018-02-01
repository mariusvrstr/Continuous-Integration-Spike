
namespace Spike.Tests.TypesOfTesting
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using Spike.Contracts.Users;
    using Spike.Orchestrations;

    [TestClass]
    public class MockedUnitTests
    {
        private const string samplePassword = "SamplePassword";
        private const string SampleHashValue = "ffcb27f37a1c572def72397b3cb2471f4a4b51a428fabfc112b6727df6c73985";

        private IUserAdapter GetMockedUserAdapter()
        {
            var mok = MockRepository.GenerateMock<IUserAdapter>();
            mok.Stub(e => e.GetPasswordHash(Arg<string>.Is.Anything)).Return(SampleHashValue);

            return mok;
        }

        [TestMethod]
        public void Mocked_TestUserLoginMustSucceed()
        {
            var username = "UsernameThatWillFail";
            var orchestrator = new SecurityOrchestration(GetMockedUserAdapter());

            var response = orchestrator.Login(username, samplePassword);
            Assert.IsTrue(response, $"The adpater is mocked against the [{samplePassword}] hash");
        }

        [TestMethod]
        public void Mocked_TestUserLoginMustFail()
        {
            var username = "UsernameThatWillSucceed";
            var password = "WrongPassword";

            var orchestrator = new SecurityOrchestration(GetMockedUserAdapter());
            var response = orchestrator.Login(username, password);

            Assert.IsFalse(response, "Any ");
        }
    }
}
