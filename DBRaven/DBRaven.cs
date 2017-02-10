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

        public List<Recipe> GetRecipesDecendingOrder(int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Recipe>().OrderByDescending(p => p.ID).Take(Count).ToList();
            }
        }

        public List<Recipe> GetRecipesPublishedDecendingOrder(int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Recipe>().Where(p => p.Published == true).OrderByDescending(p => p.ID).Take(Count).ToList();
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

        public int SaveIngredient(Ingredient Ingredient)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(Ingredient);
                session.SaveChanges();
            }

            return -1;
        }

        public void DeleteIngredient(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<Ingredient>(Id);
                session.SaveChanges();
            }
        }

        public List<Ingredient> GetIngredients(int RecipeId, int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Ingredient>().Take(Count).ToList();
            }
        }

        public int SaveGroup(Group Group)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(Group);
                session.SaveChanges();
            }

            return -1;
        }

        public void DeleteGroup(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<Group>(Id);
                session.SaveChanges();
            }
        }

        public Group GetGroup(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Load<Group>(Id);
            }
        }

        public List<Group> GetGroups(int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Group>().Take(Count).ToList();
            }
        }
    }
}
