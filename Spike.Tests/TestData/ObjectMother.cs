
namespace Spike.Tests.TestData
{
    using Spike.Adapters.Database;
    using Spike.Contracts;
    using Spike.Contracts.Entities;
    using Spike.SDK;
    using Spike.Tests.Builders;
    using System.Linq;

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
        
        public static void Flush()
        {
            var context = new DataContext();

            if (context.Users.Any())
            {
                context.Database.ExecuteSqlCommand("delete from UserEntities");
                context.SaveChanges();

                instance = null;
            }          
        }

        public bool Refresh()
        {
            instance = new ObjectMother();
            instance.Initialize();

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
