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
        public List<Recipe> GetRecipesFromGroup(int group)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Recipe>().Where(p => p.GroupId == group).ToList();
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
                return session.Query<Ingredient>().Where(p => p.Id == RecipeId).Take(Count).ToList();
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

        public Ingredient GetIngredient(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Load<Ingredient>(Id);
            }
        }

        public Ingredient GetIngredient(string Name)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Ingredient>().Where(p => p.Name == Name).FirstOrDefault();
            }
        }

        public List<Ingredient> GetIngredients(int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<Ingredient>().Take(Count).ToList();
            }
        }

        public int SaveRecipeIngredient(RecipeIngredient ingredient)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(ingredient);
                session.SaveChanges();
            }

            return -1;
        }

        public List<RecipeIngredient> GetRecipeIngredients(int RecipeId, int Count)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<RecipeIngredient>().Where(p => p.RecipeId == RecipeId).Take(Count).ToList();
            }
        }

        public RecipeIngredient GetRecipeIngredient(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Load<RecipeIngredient>(Id);
            }
        }

        public void DeleteRecipeIngredient(int Id)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<RecipeIngredient>(Id);
                session.SaveChanges();
            }
        }

        /* IDatabaseQuery implementations */
        public List<T> GetList<T>() where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public List<T> GetList<T>(int Count) where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Query<T>().Take(Count).ToList();
            }
        }

        public T Load<T>(int Id) where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                return session.Load<T>(Id);
            }
        }

        public int Store<T>(T obj) where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Store(obj);
                session.SaveChanges();
            }

            return -1;
        }

        public List<int> Store<T>(List<T> list) where T : DBBaseItem
        {
            var ids = new List<int>();

            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                foreach (var item in list)
                {
                    session.Store(item);
                    ids.Add(-1);
                }

                session.SaveChanges();
            }

            return ids;
        }

        public void Delete<T>(int Id) where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<T>(Id);
            }
        }

        public void Delete<T>(T obj) where T : DBBaseItem
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete(obj);
            }
        }
    }
}
