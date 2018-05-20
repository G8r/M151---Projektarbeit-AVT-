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
    public class ModulController : Controller
    {
        private AbsenzenDBEntities db = new AbsenzenDBEntities();

        // GET: Modul
        public ActionResult Index()
        {
            var moduls = db.Moduls.Include(m => m.Lehrer);
            return View(moduls.ToList());
        }

        // GET: Modul/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // GET: Modul/Create
        public ActionResult Create()
        {
            ViewBag.lehrer_id = new SelectList(db.Lehrers, "lehrer_id", "Vorname");
            return View();
        }

        // POST: Modul/Create
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modul_id,Bezeichnung,lehrer_id")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Moduls.Add(modul);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.lehrer_id = new SelectList(db.Lehrers, "lehrer_id", "Vorname", modul.lehrer_id);
            return View(modul);
        }

        // GET: Modul/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            ViewBag.lehrer_id = new SelectList(db.Lehrers, "lehrer_id", "Vorname", modul.lehrer_id);
            return View(modul);
        }

        // POST: Modul/Edit/5
        // Aktivieren Sie zum Schutz vor übermäßigem Senden von Angriffen die spezifischen Eigenschaften, mit denen eine Bindung erfolgen soll. Weitere Informationen 
        // finden Sie unter https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modul_id,Bezeichnung,lehrer_id")] Modul modul)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modul).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.lehrer_id = new SelectList(db.Lehrers, "lehrer_id", "Vorname", modul.lehrer_id);
            return View(modul);
        }

        // GET: Modul/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Modul modul = db.Moduls.Find(id);
            if (modul == null)
            {
                return HttpNotFound();
            }
            return View(modul);
        }

        // POST: Modul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul modul = db.Moduls.Find(id);
            db.Moduls.Remove(modul);
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
