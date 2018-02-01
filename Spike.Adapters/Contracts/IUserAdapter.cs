
namespace Spike.Adapters.Contracts
{
    using Spike.Contracts.Entities;

    public interface IUserAdapter
    {
        UserEntity AddUser(UserEntity newUser);

        string GetPasswordHash(string username);

        int SaveChanges();
    }
}
