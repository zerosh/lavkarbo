using DBFactory;
using System.Collections.Generic;
using DBFactory.Structures;
using System.Linq;

namespace DBMSSQL
{
    public class DBMSSQL : IDBBase
    {
        MySqlContext context = new MySqlContext();

        public List<Recipe> GetRecipes(int Count)
        {
            return context.Recipe.Take(Count).ToList();
        }

        public Recipe GetRecipe(int ID)
        {
            return context.Recipe.Find(ID);
        }

        public int SaveRecipe(Recipe Recipe)
        {
            context.Recipe.Add(Recipe);
            context.SaveChanges();
            return Recipe.ID;
        }

        public void DeleteRecipe(int ID)
        {
            context.Recipe.Remove(GetRecipe(ID));
        }
    }
}
