using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbsenzenVerwaltungsTool.Models;
using AbsenzenVerwaltungsTool.Models.UoW;

namespace AbsenzenVerwaltungsTool.Controllers
{
    public class SchuelersController : Controller
    {
        IUnitOfWork unitOfWork;

        public SchuelersController()
        {
            this.unitOfWork = new UnitOfWork<AbsenzenDBEntities>();
        }

        public ViewResult Index()
        {
            var schueler = unitOfWork.GetRepository<Schueler>().Get();
            return View(schueler.ToList());
        }

        // GET: /Schueler/Details/5
        public ViewResult Details(int id)
        {
            Schueler schueler = unitOfWork.GetRepository<Schueler>().GetByID(id);
            return View(schueler);
        }

        // GET: Schueler/Create
        public ActionResult Create()
        {
            var schueler = unitOfWork.GetRepository<Schueler>().Get();
            var klasse  = unitOfWork.GetRepository<Klasse>().Get();

            ViewBag.klasse_id = new SelectList(klasse, "klasse_id", "Bezeichnung");
            return View();
        }


        // POST: Schueler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
          [Bind(Include = "schueler_id, Vorname, Nachname, klasse_id")] Schueler schueler)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Schueler>().Insert(schueler);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateSchuelerDropDownList(schueler.schueler_id);
            return View(schueler);
        }

        // GET: /Schueler/Edit/
        public ActionResult Edit(int id)
        {
            Schueler schuelere = unitOfWork.GetRepository<Schueler>().GetByID(id);
            var klasse = unitOfWork.GetRepository<Klasse>().Get();

            ViewBag.klasse_id = new SelectList(klasse, "klasse_id", "Bezeichnung");

            PopulateSchuelerDropDownList(schuelere.schueler_id);
            return View(schuelere);
        }

        // POST: /Schueler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "schueler_id, Vorname, Nachname, klasse_id")] Schueler schueler)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Schueler>().Update(schueler);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateSchuelerDropDownList(schueler.schueler_id);
            return View(schueler);
        }

        // GET: /Schueler/Delete/
        public ActionResult Delete(int id)
        {
            Schueler schueler = unitOfWork.GetRepository<Schueler>().GetByID(id);
            return View(schueler);
        }

        // POST: /Schueler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Schueler course = unitOfWork.GetRepository<Schueler>().GetByID(id);
            unitOfWork.GetRepository<Schueler>().Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateSchuelerDropDownList(object selectedSchueler = null)
        {
            var SchuelerQuery = unitOfWork.GetRepository<Schueler>().Get(
                orderBy: q => q.OrderBy(d => d.schueler_id));
            ViewBag.SchuelerID = new SelectList(SchuelerQuery, "schueler_id", "schueler_id", selectedSchueler);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
