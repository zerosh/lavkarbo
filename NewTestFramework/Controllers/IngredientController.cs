using DBFactory;
using DBFactory.Structures;
using NewTestFramework.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace NewTestFramework.Controllers
{
    public class IngredientController : Controller
    {
        // GET: Ingredient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var rec = new CreateRecipeViewModel();
            return View(rec);
        }

        [HttpPost]
        public ActionResult Create(CreateRecipeViewModel model)
        {
            var ingredient = DB.Instance.GetIngredient(model.IngredientName);

            if (ingredient == null)
                DB.Instance.SaveIngredient(new Ingredient(model.IngredientName));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AutoComplete(string term)
        {
            if (string.IsNullOrEmpty(term))
                return Json("", JsonRequestBehavior.DenyGet);

            var ingredients = DBFactory.DB.Instance.GetIngredients(int.MaxValue);
            var data = ingredients.Where(p => p.Name.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0).Select(p => p.Name);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            DB.Instance.DeleteIngredient(id);

            return RedirectToAction("Index");
        }
    }
}
