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
        List<Recipe> GetRecipes(int Count);
        Recipe GetRecipe(int ID);
        int SaveRecipe(Recipe Recipe);
        void DeleteRecipe(int ID);

        int SaveIngredient(Ingredient Ingredient);
        void DeleteIngredient(int Id);
        List<Ingredient> GetIngredients(int RecipeId, int Count);

        int SaveGroup(Group Group);
        void DeleteGroup(int Id);
        Group GetGroup(int Id);
        List<Group> GetGroups(int Count);
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
