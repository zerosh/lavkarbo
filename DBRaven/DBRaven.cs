using DBFactory;
using DBFactory.Structures;
using Raven.Client;
using System.Collections.Generic;
using System.Linq;

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

            return -1;
        }

        public void DeleteRecipe(int ID)
        {
            using (IDocumentSession session = RavenStore.Store.OpenSession())
            {
                session.Delete<Recipe>(ID);
            }
        }
    }
}
