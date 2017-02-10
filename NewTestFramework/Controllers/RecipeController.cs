using DBFactory;
using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTestFramework.Controllers
{
    public class RecipeController : Controller
    {
        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View(new Recipe());
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            try
            {
                recipe.SetImage(Request.Files);
                DB.Instance.SaveRecipe(recipe);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        public ActionResult Delete(int id)
        {
            DB.Instance.DeleteRecipe(id);

            return RedirectToAction("Index");
        }
    }
}
