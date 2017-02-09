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
    public static class CurrentUser
    {
        private static User User = null;
        static public int Id { get { return IsAuthenticated != false ? User.Id : int.MinValue; } }
        static public UserRoles? Role { get { return IsAuthenticated != false ? User.Role : null; } }
        static public string FirstName { get { return IsAuthenticated != false ? User.FirstName : string.Empty; } }
        static public string LastName { get { return IsAuthenticated != false ? User.LastName : string.Empty; } }
        static public string Username { get { return IsAuthenticated != false ? User.Username : string.Empty; } }

        public static bool IsAuthenticated
        {
            get
            {
                if (User != null)
                {
                    return true;
                }

                return false;
            }
        }

        public static bool Login(string Username, string Password)
        {
            var user = IdentityFactory.GetUser(Username);

            if (user.VerifyPassword(Username, Password))
            {
                User = user;

                FormsAuthentication.Initialize();
                FormsAuthentication.SetAuthCookie(Username, false);
                
                return true;
            }

            return false;
        }

        public static void LogOut()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session.Abandon();

            User = null;
        }
    }

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
