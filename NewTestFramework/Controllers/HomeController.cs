using System.Web.Mvc;
using DBFactory;
using DBRavenImplementation;

namespace NewTestFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            DB.Instance.SaveGroup(new DBFactory.Structures.Group("Bakst"));

            var cake = new DBFactory.Structures.Recipe("Kake", 0);
            int id = DB.Instance.SaveRecipe(cake);

            var recipe = DB.Instance.GetRecipe(id);
            
            var ingredient = new DBFactory.Structures.Ingredient(id, "Egg", 6);
            DB.Instance.SaveIngredient(ingredient);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}