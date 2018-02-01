
namespace Spike.Contracts.Entities
{
    using System;

    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }
    }
}
