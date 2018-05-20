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
    public class LehrerController : Controller
    {
        private AbsenzenDBEntities db = new AbsenzenDBEntities();

        // GET: Lehrer
        public ActionResult Index()
        {
            return View(db.Lehrers.ToList());
        }

        // GET: Lehrer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lehrer lehrer = db.Lehrers.Find(id);
            if (lehrer == null)
            {
                return HttpNotFound();
            }
            return View(lehrer);
        }

        // GET: Lehrer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lehrer/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "lehrer_id,Vorname,Nachname")] Lehrer lehrer)
        {
            if (ModelState.IsValid)
            {
                db.Lehrers.Add(lehrer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lehrer);
        }

        // GET: Lehrer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lehrer lehrer = db.Lehrers.Find(id);
            if (lehrer == null)
            {
                return HttpNotFound();
            }
            return View(lehrer);
        }

        // POST: Lehrer/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "lehrer_id,Vorname,Nachname")] Lehrer lehrer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lehrer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lehrer);
        }

        // GET: Lehrer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lehrer lehrer = db.Lehrers.Find(id);
            if (lehrer == null)
            {
                return HttpNotFound();
            }
            return View(lehrer);
        }

        // POST: Lehrer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lehrer lehrer = db.Lehrers.Find(id);
            db.Lehrers.Remove(lehrer);
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
