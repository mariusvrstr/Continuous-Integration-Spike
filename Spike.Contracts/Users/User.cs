﻿
namespace Spike.Contracts.Users
{
    using System;
    
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
