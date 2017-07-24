
namespace Spike.Stubs.Orchestrations
{
    using Contracts;

    public class SecurityOrchestrationStub : ISecurityOrchestration
    {
        public bool Login(string username, string password)
        {
            return !string.IsNullOrEmpty(username) && !username.ToLower().Contains("fail");
        }
    }
}
