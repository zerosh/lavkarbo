using DBFactory;
using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace IdentityFactory
{
    public static class IdentityFactory
    {
        private static IDBBase DB = null;

        public static void Initialize(IDBBase DB)
        {
            IdentityFactory.DB = DB;
        }

        public static User CreateUser(string Username, string Password)
        {
            ThrowIfNotInitialized();

            var user = new User(Username, Password);
            return DB.SaveUser(user);
        }

        public static User SaveUser(User User)
        {
            ThrowIfNotInitialized();

            return DB.SaveUser(User);
        }

        public static User GetUser(string Username)
        {
            ThrowIfNotInitialized();

            return DB.GetUser(Username);
        }

        public static void DeleteUser(string Username)
        {
            ThrowIfNotInitialized();

            DB.DeleteUser(Username);
        }

        private static void ThrowIfNotInitialized()
        {
            if (IdentityFactory.DB == null)
            {
                throw new Exception("IdentityFactory is not initialized.");
            }
        }
    }
}
