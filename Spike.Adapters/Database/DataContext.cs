
namespace Spike.Adapters.Database
{
    using Spike.Contracts.Entities;
    using System.Data.Entity;

    public class DataContext : DbContext, IDataContext
    {
        public DbSet<UserEntity> Users { get; set; }
    }
}
