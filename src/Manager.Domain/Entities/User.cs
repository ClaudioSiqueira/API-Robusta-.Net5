using System;
using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public class User : Base
    {
        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();
        }
        // EF
        protected User() { }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public override bool Validate()
        {
            throw new NotImplementedException();
        }
        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }

    }
}

