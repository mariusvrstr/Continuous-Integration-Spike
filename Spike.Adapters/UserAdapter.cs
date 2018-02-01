
namespace Spike.Adapters
{
    using Spike.Adapters.Contracts;
    using Spike.Adapters.Database;
    using Spike.Contracts.Entities;
    using System.Linq;

    public class UserAdapter : IUserAdapter
    {
        public UserEntity AddUser(UserEntity newUser)
        {
            var updatedUser = Context.Users.Add(newUser);
            return updatedUser;
        }

        public string GetPasswordHash(string username)
        {
            return Context.Users.FirstOrDefault(u => u.Username == username)?.PasswordHash;
        }

        private IDataContext context { get; set; }
        protected IDataContext Context { get => context ?? (context = ContextFactory.Create()); }

        public int SaveChanges() => Context.SaveChanges();
    }
}
