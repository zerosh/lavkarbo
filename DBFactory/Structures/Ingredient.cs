using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(int RecipeId, string Name, int Amount)
        {
            this.RecipeId = RecipeId;
            this.Name = Name;
            this.Amount = Amount;
        }
    }
}
