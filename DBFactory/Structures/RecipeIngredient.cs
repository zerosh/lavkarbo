using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory.Structures
{
    public enum RecipeMesurement
    {
        Kilogram,
        Gram,
        Milligram,

        Liter,
        Desiliter,
        Centiliter,
        Milliliter,

        Teskje,
        Spiseskje,
        Stk,
        Ingen
    }

    /*
     * Data that describes the connection between a recipe ingredient and a Ingredient.
     * RecipeIngredients -> Ingredient
     */
    public class RecipeIngredient
    {
        [Key]
        public int Id { get; set; }
        public int IngredientId { get; set; }
        public float Amount { get; set; }
        public int RecipeId { get; set; }
        public RecipeMesurement Mesurement { get; set; }

        public string FormattedText
        {
            get
            {
                switch (Mesurement)
                {
                    case RecipeMesurement.Ingen:
                        return string.Format("");
                    default:
                        return string.Format("{0} {1}", Amount, GetMesurementType());
                }
            }
        }

        public string GetMesurementType()
        {
            switch (Mesurement)
            {
                case RecipeMesurement.Kilogram:
                    return "kg";
                case RecipeMesurement.Gram:
                    return "gram";
                case RecipeMesurement.Milligram:
                    return "mg";
                case RecipeMesurement.Liter:
                    return "liter";
                case RecipeMesurement.Desiliter:
                    return "dl";
                case RecipeMesurement.Centiliter:
                    return "cl";
                case RecipeMesurement.Milliliter:
                    return "ml";
                case RecipeMesurement.Stk:
                    return "stk";
                case RecipeMesurement.Teskje:
                    return "ts";
                case RecipeMesurement.Spiseskje:
                    return "ss";
                default:
                    return "";
            }
        }

        public RecipeIngredient()
        {
        }

        public RecipeIngredient(int IngredientId, float Amount, RecipeMesurement Mesurement)
        {
            this.IngredientId = IngredientId;
            this.Amount = Amount;
            this.Mesurement = Mesurement;
        }
    }
}
