using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTestFramework.Models
{
    public class AddRecipeIngredientViewModel
    {
        public AddRecipeIngredientViewModel()
        {
        }

        public AddRecipeIngredientViewModel(int id)
        {
            this.RecipeId = id;
        }
        public string IngredientName { get; set; }
        public float Amount { get; set; }
        public int RecipeId { get; set; }

        public RecipeMesurement Mesurement { get; set; }
    }
}