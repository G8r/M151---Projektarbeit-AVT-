using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbsenzenVerwaltungsTool.Models.UoW;
using AbsenzenVerwaltungsTool.Models;

namespace KlasseenVerwaltungsTool.Controllers
{
    public class KlassesController : Controller
    {
        IUnitOfWork unitOfWork;

        public KlassesController()
        {
            this.unitOfWork = new UnitOfWork<AbsenzenDBEntities>();
        }

        public ViewResult Index()
        {
            var Klasseen = unitOfWork.GetRepository<Klasse>().Get();
            return View(Klasseen.ToList());
        }

        // GET: /Klasse/Details/5
        public ViewResult Details(int id)
        {
            Klasse Klasse = unitOfWork.GetRepository<Klasse>().GetByID(id);
            return View(Klasse);
        }

        // GET: Klasse/Create
        public ActionResult Create()
        {
            var Klasse = unitOfWork.GetRepository<Klasse>();
            return View();
        }


        // POST: Klasse/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
          [Bind(Include = "klasse_id, Bezeichnung")] Klasse Klasse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Klasse>().Insert(Klasse);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateKlasseDropDownList(Klasse.klasse_id);
            return View(Klasse);
        }

        // GET: /Klasse/Edit/
        public ActionResult Edit(int id)
        {
            Klasse Klasse = unitOfWork.GetRepository<Klasse>().GetByID(id);

            PopulateKlasseDropDownList(Klasse.klasse_id);
            return View(Klasse);
        }

        // POST: /Klasse/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "klasse_id, Bezeichnung")] Klasse klasse)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Klasse>().Update(klasse);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateKlasseDropDownList(klasse.klasse_id);
            return View(klasse);
        }

        // GET: /Klasse/Delete/
        public ActionResult Delete(int id)
        {
            Klasse Klasse = unitOfWork.GetRepository<Klasse>().GetByID(id);
            return View(Klasse);
        }

        // POST: /Klasse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klasse course = unitOfWork.GetRepository<Klasse>().GetByID(id);
            unitOfWork.GetRepository<Klasse>().Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateKlasseDropDownList(object selectedKlasseen = null)
        {
            var KlasseenQuery = unitOfWork.GetRepository<Klasse>().Get(
                orderBy: q => q.OrderBy(d => d.klasse_id));
            ViewBag.KlasseenID = new SelectList(KlasseenQuery, "klasse_id", "klasse_id", selectedKlasseen);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
