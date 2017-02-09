using DBFactory;
using System.Collections.Generic;
using DBFactory.Structures;

namespace DBMSSQL
{
    public class DBMSSQL : IDBBase
    {
        public List<Recipe> GetRecipes()
        {
            return new List<Recipe>();
        }

        public Recipe GetRecipe(int ID)
        {
            return new Recipe();
        }

        public void SaveRecipe(Recipe Recipe)
        {
            var tetst = new tetst();
            tetst.Recipe.
        }

        public void DeleteRecipe(int ID)
        {
            
        }
    }
}
