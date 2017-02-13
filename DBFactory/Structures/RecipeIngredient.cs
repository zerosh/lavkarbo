using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    /*
     * Data that describes the connection between a recipe ingredient and a Ingredient.
     * RecipeIngredients -> Ingredient
     */
    public class RecipeIngredient
    {
        [Key]
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public int RecipeId { get; set; }

        public RecipeIngredient()
        {
        }

        public RecipeIngredient(int IngredientId, int RecipeId, int Amount)
        {
            this.IngredientId = IngredientId;
            this.RecipeId = RecipeId;
            this.Amount = Amount;
        }
    }
}
