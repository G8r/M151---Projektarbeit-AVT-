using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbsenzenVerwaltungsTool.Models;

namespace AbsenzenVerwaltungsTool.Controllers
{
    public class SchuelerController : Controller
    {
        private AbsenzenDBEntities db = new AbsenzenDBEntities();

        // GET: Schueler
        public ActionResult Index()
        {
            var schuelers = db.Schuelers.Include(s => s.Klasse);
            return View(schuelers.ToList());
        }

        // GET: Schueler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schueler schueler = db.Schuelers.Find(id);
            if (schueler == null)
            {
                return HttpNotFound();
            }
            return View(schueler);
        }

        // GET: Schueler/Create
        public ActionResult Create()
        {
            ViewBag.klasse_id = new SelectList(db.Klasses, "klasse_id", "Bezeichnung");
            return View();
        }

        // POST: Schueler/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "schueler_id,Vorname,Nachname,klasse_id")] Schueler schueler)
        {
            if (ModelState.IsValid)
            {
                db.Schuelers.Add(schueler);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klasse_id = new SelectList(db.Klasses, "klasse_id", "Bezeichnung", schueler.klasse_id);
            return View(schueler);
        }

        // GET: Schueler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schueler schueler = db.Schuelers.Find(id);
            if (schueler == null)
            {
                return HttpNotFound();
            }
            ViewBag.klasse_id = new SelectList(db.Klasses, "klasse_id", "Bezeichnung", schueler.klasse_id);
            return View(schueler);
        }

        // POST: Schueler/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "schueler_id,Vorname,Nachname,klasse_id")] Schueler schueler)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schueler).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klasse_id = new SelectList(db.Klasses, "klasse_id", "Bezeichnung", schueler.klasse_id);
            return View(schueler);
        }

        // GET: Schueler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schueler schueler = db.Schuelers.Find(id);
            if (schueler == null)
            {
                return HttpNotFound();
            }
            return View(schueler);
        }

        // POST: Schueler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schueler schueler = db.Schuelers.Find(id);
            db.Schuelers.Remove(schueler);
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
