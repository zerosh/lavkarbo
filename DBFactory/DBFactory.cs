using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    public interface IDBBase
    {
        List<Recipe> GetRecipes();
        Recipe GetRecipe(int ID);
        void SaveRecipe(Recipe Recipe);
        void DeleteRecipe(int ID);
    }

    public static class DB
    {
        public static IDBBase Instance;
    }

    public static class DBFactory<T> where T : IDBBase, new()
    {
        public static IDBBase database = null;

        public static IDBBase CreateDB()
        {
            if (database == null)
            {
                database = new T();
            }

            return database;
        }

        public static IDBBase db
        {
            get
            {
                if (database == null)
                {
                    throw new Exception("Database not created.");
                }

                return database;
            }
        }
    }
}
