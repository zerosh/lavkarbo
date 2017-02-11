using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTestFramework.Controllers
{
    public class CartController : Controller
    {
        public List<int> Cart
        {
            get
            {
                if (Session["cart"] == null)
                {
                    Session["cart"] = new List<int>();
                }

                return ((List<int>)Session["cart"]);
            }
        }

        // GET: Cart
        public ActionResult Index()
        {
            var initCart = Cart;

            return View();
        }

        public ActionResult Add(int id)
        {
            Cart.Add(id);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            Cart.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            Cart.Remove(id);

            return RedirectToAction("Index");
        }
    }
}
