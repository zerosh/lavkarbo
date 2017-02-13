using System.Web.Mvc;
using DBFactory;
using DBRavenImplementation;
using System.Collections.Generic;

namespace NewTestFramework.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //// Store
            //var id = Query.StoreUserInfo(new DUser() { Name = "Whatever" });

            //// Load
            //var user = Query.LoadUserInfo(id);

            //// Update
            //user.Name = "random bull";
            //Query.StoreUserInfo(user);

            //// Delete
            //Query.DeleteUserInfo(user);

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