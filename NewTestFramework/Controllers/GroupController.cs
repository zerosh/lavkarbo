using DBFactory.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewTestFramework.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            return View();
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View(new Group());
        }

        [HttpPost]
        public ActionResult Create(Group Group)
        {
            DBFactory.DB.Instance.SaveGroup(Group);
            return RedirectToAction("Index");
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            //DBFactory.DB.Instance.DeleteGroup(id);
            //return RedirectToAction("Index");
            return View(DBFactory.DB.Instance.GetGroup(id));
        }

        [HttpPost]
        public ActionResult Delete(Group group)
        {

            DBFactory.DB.Instance.DeleteGroup(group.Id);
            return RedirectToAction("Index");
        }
    }
}
