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
        public int Amount { get; set; }
        public int RecipeId { get; set; }
    }
}