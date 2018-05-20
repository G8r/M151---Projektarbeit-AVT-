using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbsenzenVerwaltungsTool.Models;
using AbsenzenVerwaltungsTool.Models.Repositories;
using AbsenzenVerwaltungsTool.Models.UoW;

namespace AbsenzenVerwaltungsTool.Controllers
{
    public class AbsenzController : Controller
    {
        IUnitOfWork unitOfWork;

        public AbsenzController()
        {
            this.unitOfWork = new UnitOfWork<AbsenzenDBEntities>();
        }

        public ViewResult Index()
        {
            var absenzen = unitOfWork.GetRepository<Absenz>().Get();
            return View(absenzen.ToList());
        }

        // GET: /Absenz/Details/5
        public ViewResult Details(int id)
        {
            Absenz absenz = unitOfWork.GetRepository<Absenz>().GetByID(id);
            return View(absenz);
        }

        // GET: Absenz/Create
        public ActionResult Create()
        {
            var module = unitOfWork.GetRepository<Modul>().Get();
            var schueler = unitOfWork.GetRepository<Schueler>().Get();
            var absenz = unitOfWork.GetRepository<Absenz>();

            ViewBag.modul_id = new SelectList(module, "modul_id", "Bezeichnung");
            ViewBag.schueler_id = new SelectList(schueler, "schueler_id", "Nachname");
            
            return View();
        }


        // POST: Absenz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
          [Bind(Include = "absenz_id,Datum,Lektionen,modul_id,schueler_id")] Absenz absenz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Absenz>().Insert(absenz);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAbsenzDropDownList(absenz.absenz_id);
            return View(absenz);
        }

        // GET: /Absenz/Edit/
        public ActionResult Edit(int id)
        {
            Absenz absenz = unitOfWork.GetRepository<Absenz>().GetByID(id);
            var module = unitOfWork.GetRepository<Modul>().Get();
            var schueler = unitOfWork.GetRepository<Schueler>().Get();

            ViewBag.modul_id = new SelectList(module, "modul_id", "Bezeichnung");
            ViewBag.schueler_id = new SelectList(schueler, "schueler_id", "Nachname");

            PopulateAbsenzDropDownList(absenz.absenz_id);
            return View(absenz);
        }

        // POST: /Absenz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "absenz_id,Datum,Lektionen,modul_id,schueler_id")] Absenz absenz)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Absenz>().Update(absenz);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateAbsenzDropDownList(absenz.absenz_id);
            return View(absenz);
        }

        // GET: /Absenz/Delete/
        public ActionResult Delete(int id)
        {
            Absenz absenz = unitOfWork.GetRepository<Absenz>().GetByID(id);
            return View(absenz);
        }

        // POST: /Absenz/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Absenz course = unitOfWork.GetRepository<Absenz>().GetByID(id);
            unitOfWork.GetRepository<Absenz>().Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateAbsenzDropDownList(object selectedAbsenzen = null)
        {
            var absenzenQuery = unitOfWork.GetRepository<Absenz>().Get(
                orderBy: q => q.OrderBy(d => d.absenz_id));
            ViewBag.AbsenzenID = new SelectList(absenzenQuery, "absenz_id", "absenz_id", selectedAbsenzen);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
