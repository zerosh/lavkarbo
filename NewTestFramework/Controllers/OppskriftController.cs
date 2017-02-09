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
    public class OppskriftController : Controller
    {
        private LavkarboEntities db = new LavkarboEntities();

        // GET: Oppskrift
        public ActionResult Index()
        {
            var oppskrifts = db.Oppskrifts.Include(o => o.Grupper);
            return View(oppskrifts.ToList());
        }

        // GET: Oppskrift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oppskrift oppskrift = db.Oppskrifts.Find(id);
            if (oppskrift == null)
            {
                return HttpNotFound();
            }
            return View(oppskrift);
        }

        // GET: Oppskrift/Create
        public ActionResult Create()
        {
            ViewBag.Gruppe = new SelectList(db.Gruppers, "id", "Navn");
            return View();
        }

        // POST: Oppskrift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tittel,Innhold,Dato,Bilde,Gruppe,Publisert")] Oppskrift oppskrift)
        {
            if (ModelState.IsValid)
            {
                db.Oppskrifts.Add(oppskrift);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Gruppe = new SelectList(db.Gruppers, "id", "Navn", oppskrift.Gruppe);
            return View(oppskrift);
        }

        // GET: Oppskrift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oppskrift oppskrift = db.Oppskrifts.Find(id);
            if (oppskrift == null)
            {
                return HttpNotFound();
            }
            ViewBag.Gruppe = new SelectList(db.Gruppers, "id", "Navn", oppskrift.Gruppe);
            return View(oppskrift);
        }

        // POST: Oppskrift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tittel,Innhold,Dato,Bilde,Gruppe,Publisert")] Oppskrift oppskrift)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oppskrift).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Gruppe = new SelectList(db.Gruppers, "id", "Navn", oppskrift.Gruppe);
            return View(oppskrift);
        }

        // GET: Oppskrift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Oppskrift oppskrift = db.Oppskrifts.Find(id);
            if (oppskrift == null)
            {
                return HttpNotFound();
            }
            return View(oppskrift);
        }

        // POST: Oppskrift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Oppskrift oppskrift = db.Oppskrifts.Find(id);
            oppskrift.Ingredients.Clear();
            db.Oppskrifts.Remove(oppskrift);
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
