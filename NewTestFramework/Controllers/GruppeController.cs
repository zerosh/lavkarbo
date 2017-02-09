using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NewTestFramework.Models;

namespace NewTestFramework.Controllers
{
    public class GruppeController : Controller
    {
        private LavkarboEntities db = new LavkarboEntities();

        // GET: Gruppe
        public ActionResult Index()
        {
            return View(db.Gruppers.ToList());
        }

        // GET: Gruppe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupper grupper = db.Gruppers.Find(id);
            if (grupper == null)
            {
                return HttpNotFound();
            }
            return View(grupper);
        }

        // GET: Gruppe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gruppe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Navn")] Grupper grupper)
        {
            if (ModelState.IsValid)
            {
                db.Gruppers.Add(grupper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grupper);
        }

        // GET: Gruppe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupper grupper = db.Gruppers.Find(id);
            if (grupper == null)
            {
                return HttpNotFound();
            }
            return View(grupper);
        }

        // POST: Gruppe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Navn")] Grupper grupper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grupper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grupper);
        }

        // GET: Gruppe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grupper grupper = db.Gruppers.Find(id);
            if (grupper == null)
            {
                return HttpNotFound();
            }
            return View(grupper);
        }

        // POST: Gruppe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grupper grupper = db.Gruppers.Find(id);
            db.Gruppers.Remove(grupper);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
