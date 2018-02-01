
namespace Spike.Adapters.Database
{
    using Spike.Contracts.Entities;
    using System.Data.Entity;

    public class DataContext : DbContext, IDataContext
    {
        public DataContext() : base("Database.DataContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DbSet<UserEntity> Users { get; set; }
    }

    public class SchoolDBInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
        }
    }
}
