using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    public enum UserRoles { User = 0, Moderator = 1, Administrator = 2 }

    public class User
    {
        public int Id { get; private set; }
        public UserRoles? Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        private string Password { get; set; }

        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = ChangePassword(Password);
        }

        public string ChangePassword(string Password)
        {
            var passwordHasher = new PasswordHasher();

            return this.Password = passwordHasher.HashPassword(Password);
        }

        public bool VerifyPassword(string ProvidedPassword, string HashedPassword)
        {
            var passwordHasher = new PasswordHasher();

            if (passwordHasher.VerifyHashedPassword(HashedPassword, ProvidedPassword) == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
