
namespace Spike.Adapters
{
    using Spike.Contracts.Users;
    using System;

    public class UserAdapter : IUserAdapter
    {
        public User AddUser(User newUser)
        {
            ///TODO: This needs to go to the databse
            throw new NotImplementedException();
        }

        public string GetPasswordHash(string username)
        {
            ///TODO: This needs to go to the databse
            throw new NotImplementedException();
        }
    }
}
