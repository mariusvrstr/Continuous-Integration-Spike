
namespace Spike.Tests.Builders
{
    using Spike.Contracts.Entities;
    using Spike.Contracts.Users;
    using Spike.SDK;
    using System;

    public class UserEntityBuilder : UserEntity
    {
        public string Password { get; set; }

        public UserEntityBuilder(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
        }

        public UserEntityBuilder John()
        {
            Name = "John";
            Surname = "Doe";
            Username = "johndoe";
            Password = "password123";

            PasswordHash = HashWorker.GenerateSha256(Password);

            return this;
        }

        public UserEntityBuilder Jane()
        {
            Name = "Jane";
            Surname = "Doe";
            Username = "janedoe";
            Password = "password321";

            PasswordHash = HashWorker.GenerateSha256(Password);

            return this;
        }

        public UserEntity Build()
        {
            return new UserEntity
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Username = Username,
                PasswordHash = PasswordHash
            };
        }

        public User BuildUser()
        {
            return new User
            {
                Id = Id,
                Name = Name,
                Surname = Surname,
                Username = Username,
                Password = Password
            };
        }
    }
}
