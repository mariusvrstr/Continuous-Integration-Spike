
namespace Spike.Tests
{
    using Spike.Contracts;
    using Spike.Orchestrations;
    using Spike.SDK;
    using Spike.Stubs.Orchestrations;

    public class OrchestrationFactory
    {
        public static ISecurityOrchestration CreateSecurityOrchestration(bool isStubbed = false, bool useDI = true)
        {
            if (!useDI)
            {
                return isStubbed ? (ISecurityOrchestration)new SecurityOrchestrationStub() : (ISecurityOrchestration)new SecurityOrchestration();

            }
            else
            {
                // NOTE: This works locally but in Team City the DI does not resolve
                return isStubbed ? UnityFactory.Resolve<ISecurityOrchestration>("StubbedVersion") 
                    : UnityFactory.Resolve<ISecurityOrchestration>("LatestVersion");

            }
        }
    }
}
