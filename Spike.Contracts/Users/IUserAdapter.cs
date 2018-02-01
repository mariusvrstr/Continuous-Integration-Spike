
namespace Spike.Contracts.Users
{
    public interface IUserAdapter
    {
        User AddUser(User newUser);

        string GetPasswordHash(string username);
    }
}
