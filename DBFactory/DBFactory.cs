using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    /* 
     * Base class for all database entries, everything that will be stored in the database will inherit this class.
     */
    public class DBBaseItem
    {
        public int Id { get; set; }
    }

    // DB test class.
    public class DUser : DBBaseItem
    {
        public string Name { get; set; }
    }

    /* Contains all the DB query instructions */
    public static class Query
    {
        public static DUser GetUser(int Id)
        {
            return DB.Instance.Load<DUser>(Id);
        }

        public static List<DUser> GetUserList()
        {
            return DB.Instance.GetList<DUser>(int.MaxValue);
        }

        public static List<DUser> GetUserList(int Count)
        {
            return DB.Instance.GetList<DUser>(Count);
        }

        public static DUser LoadUserInfo(int Id)
        {
            return DB.Instance.Load<DUser>(Id);
        }

        public static void DeleteUser(string Username)
        {
            var user = DB.Instance.GetList<DUser>().Where(p => p.Name == Username).FirstOrDefault();

            if (user != null)
                DB.Instance.Delete(user);
        }

        public static int StoreUserInfo(DUser user)
        {
            return DB.Instance.Store(user);
        }

        public static void DeleteUserInfo(DUser user)
        {
            DB.Instance.Delete(user);
        }

        public static List<int> StoreUserList(List<DUser> users)
        {
            return DB.Instance.Store(users);
        }

        public static List<DUser> GetUserListOrderDecendingId(int Count)
        {
            return DB.Instance.GetList<DUser>().OrderByDescending(p => p.Id).Take(Count).ToList();
        }
    }

    public interface IDatabaseQuery
    {
        List<T> GetList<T>() where T : DBBaseItem;
        List<T> GetList<T>(int Count) where T : DBBaseItem;
        T Load<T>(int Id) where T : DBBaseItem;
        int Store<T>(T obj) where T : DBBaseItem;
        List<int> Store<T>(List<T> list) where T : DBBaseItem;
        void Delete<T>(int Id) where T : DBBaseItem;
        void Delete<T>(T obj) where T : DBBaseItem;
    }

    public interface IDBBase : IDatabaseQuery
    {
        List<Recipe> GetRecipes(int Count);
        List<Recipe> GetRecipesDecendingOrder(int Count);
        List<Recipe> GetRecipesPublishedDecendingOrder(int Count);
        Recipe GetRecipe(int ID);
        List<Recipe> GetRecipesFromGroup(int group);
        int SaveRecipe(Recipe Recipe);
        void DeleteRecipe(int ID);


        User SaveUser(User User);
        User GetUser(string Username);
        void DeleteUser(string Username);

        int SaveIngredient(Ingredient Ingredient);
        void DeleteIngredient(int Id);
        Ingredient GetIngredient(int Id);
        Ingredient GetIngredient(string Name);
        List<Ingredient> GetIngredients(int Count);

        int SaveGroup(Group Group);
        void DeleteGroup(int Id);
        Group GetGroup(int Id);
        List<Group> GetGroups(int Count);

        int SaveRecipeIngredient(RecipeIngredient ingredient);
        List<RecipeIngredient> GetRecipeIngredients(int RecipeId, int Count);
        RecipeIngredient GetRecipeIngredient(int Id);
        void DeleteRecipeIngredient(int Id);
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
