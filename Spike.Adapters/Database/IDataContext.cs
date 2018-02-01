
namespace Spike.Adapters.Database
{
    using Spike.Contracts.Entities;
    using System.Data.Entity;
    
    public interface IDataContext
    {
        DbSet<UserEntity> Users { get; }

        int SaveChanges();
    }
}
