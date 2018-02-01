
namespace Spike.Orchestrations
{
    using Spike.Contracts;
    using Spike.Contracts.Users;
    using Spike.SDK;
    using System;

    public class SecurityOrchestration : ISecurityOrchestration
    {
        private IUserAdapter _userAdapter { get; set; }

        public SecurityOrchestration(IUserAdapter userAdapter = null)
        {
            _userAdapter = userAdapter ?? UnityFactory.Resolve<IUserAdapter>();
        }


        public bool Login(string username, string password)
        {
            var storedPasswordhash = _userAdapter.GetPasswordHash(username);

            if (string.IsNullOrWhiteSpace(storedPasswordhash))
            {
                return false;
            }

            var generateProvidedPasswordHash = HashWorker.GenerateSha256(password);
            return string.Equals(storedPasswordhash, generateProvidedPasswordHash);
        }
    }
}
