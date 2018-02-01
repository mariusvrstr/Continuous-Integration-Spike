
namespace Spike.Tests.TestData
{
    using Spike.Adapters.Contracts;
    using Spike.Contracts.Entities;
    using Spike.SDK;
    using Spike.Tests.Builders;

    public class ObjectMother
    {
        private static ObjectMother instance { get; set; }

        public static ObjectMother Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                instance = new ObjectMother();
                instance.Initialize();

                return instance;
            }

        }

        private void Initialize()
        {
            Users = new UserEntities();
        }

        public bool Refresh()
        {
            return true;
        }

        public UserEntities Users { get; set; }   
    }

    public class UserEntities
    {
        public UserEntities()
        {
            var userAdapter = UnityFactory.Resolve<IUserAdapter>();

            JohnDoe = userAdapter.AddUser(new UserEntityBuilder().John().Build());
            JaneDoe = userAdapter.AddUser(new UserEntityBuilder().Jane().Build());

            userAdapter.SaveChanges();
        }

        public UserEntity JohnDoe { get; set; }
        public UserEntity JaneDoe { get; set; }
    }
}
