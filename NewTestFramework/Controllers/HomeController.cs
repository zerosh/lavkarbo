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

            var cake = new DBFactory.Structures.Recipe("Kake");
            int id = DB.Instance.SaveRecipe(cake);

            var recipe = DB.Instance.GetRecipe(id);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}