using DBFactory;
using DBFactory.Structures;
using NewTestFramework.Models;
using System.Linq;
using System.Web.Mvc;

namespace NewTestFramework.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View(DB.Instance.GetRecipes(int.MaxValue));
        }

        public ActionResult Ingredient(int id)
        {
            var recipe = new AddRecipeIngredientViewModel(id, DB.Instance.GetRecipe(id));
            return View(recipe);
        }

        [HttpPost]
        public ActionResult Ingredient(AddRecipeIngredientViewModel model)
        {
            var ingredient = DB.Instance.GetIngredient(model.IngredientName);

            int id = 0;
            if (ingredient == null)
            {
                id = DB.Instance.SaveIngredient(new Ingredient(model.IngredientName));
            }
            else
            {
                id = ingredient.Id;
            }

            var recipe = DB.Instance.GetRecipe(model.RecipeId);
            recipe.Ingredients.Add(new RecipeIngredient(id, model.Amount, model.Mesurement));
            DB.Instance.SaveRecipe(recipe);

            return RedirectToAction("Ingredient", "Recipe", model);
        }

        public ActionResult TogglePublished(int Id)
        {
            var recipe = DB.Instance.GetRecipe(Id);
            recipe.Published = !recipe.Published;
            DB.Instance.SaveRecipe(recipe);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteIngredient(int id, int recipeId)
        {
            DB.Instance.DeleteRecipeIngredient(id);
            return RedirectToAction("Ingredient/" + recipeId, "Recipe");
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View(new Recipe());
        }

        public ActionResult Edit(int id)
        {
            var recipe = DB.Instance.GetRecipe(id);

            return View(recipe);
        }

        [HttpPost]
        public ActionResult Edit(Recipe recipe)
        {
            DB.Instance.SaveRecipe(recipe);
            return RedirectToAction("Index");
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            try
            {
                if (Request.Files != null)
                {
                    recipe.FinishedMealImage.SaveImage(Request.Files[0], 1024, 600);
                    int id = DB.Instance.SaveRecipe(recipe);
                    return RedirectToAction("Ingredient", new { id = id }); // redirect to adding ingredients to this recipe.
                    //return RedirectToAction("Index");
                }

                return null;
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            return View(DB.Instance.GetRecipe(id));
        }

        [HttpPost]
        public ActionResult Delete(Recipe recipe)
        {
            if (recipe != null)
            {
                DB.Instance.DeleteRecipe(recipe.ID);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int Id)
        {
            return View(DB.Instance.GetRecipe(Id));
        }

        public ActionResult ViewGroup(int Id)
        {
            return View(DB.Instance.GetRecipesFromGroup(Id).Where(p => p.Published == true).OrderByDescending(p => p.ID).ToList());
        }
    }
}
