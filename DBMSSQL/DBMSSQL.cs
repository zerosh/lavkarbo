using DBFactory;
using System.Collections.Generic;
using DBFactory.Structures;

namespace DBMSSQL
{
    public class DBMSSQL : IDBBase
    {
        MySqlContext context = new MySqlContext();

        public List<Recipe> GetRecipes()
        {
            return new List<Recipe>();
        }

        public Recipe GetRecipe(int ID)
        {
            return context.Recipe.Find(ID);
        }

        public void SaveRecipe(Recipe Recipe)
        {
            context.Recipe.Add(Recipe);
            context.SaveChanges();
        }

        public void DeleteRecipe(int ID)
        {
            
        }
    }
}
