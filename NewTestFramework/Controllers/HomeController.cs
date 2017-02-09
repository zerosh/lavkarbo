using System.Web.Mvc;
using DBFactory;
using DBRavenImplementation;

namespace NewTestFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var cake = new DBFactory.Structures.Recipe("Kake");
            DB.Instance.SaveRecipe(cake);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}