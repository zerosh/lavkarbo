using DBFactory;
using DBFactory.Structures;
using Raven.Client;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DBRavenImplementation
{
    public class DBRaven : IDBBase
    {
        public List<Recipe> GetRecipes(int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Recipe>().Take(Count).ToList();
            }
        }

        public Recipe GetRecipe(int ID)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Load<Recipe>(ID);
            }
        }

        public int SaveRecipe(Recipe Recipe)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(Recipe);
                session.SaveChanges();
            }

            return Recipe.ID;
        }

        public void DeleteRecipe(int ID)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<Recipe>(ID);
            }
        }

        public User SaveUser(User User)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(User);
                session.SaveChanges();
            }

            return User;
        }

        public User GetUser(string Username)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<User>().Where(x => x.Username == Username).FirstOrDefault();
            }
        }

        public void DeleteUser(string Username)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                var user = session.Query<User>().Where(x => x.Username == Username).FirstOrDefault();

                if (user != null)
                {
                    session.Delete<User>(user);
                }
            }
        }
    }
}
