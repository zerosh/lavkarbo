using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewTestFramework.Models
{
    public enum IngredientMesurements
    {
        DL,
        Liter,
        Stk
    }

    public class CreateRecipeViewModel
    {
        public IngredientMesurements Mesurement { get; set; }
        public int Antall { get; set; }
        public string IngredientName { get; set; }

        public CreateRecipeViewModel()
        {
            Mesurement = IngredientMesurements.DL;
        }
    }
}