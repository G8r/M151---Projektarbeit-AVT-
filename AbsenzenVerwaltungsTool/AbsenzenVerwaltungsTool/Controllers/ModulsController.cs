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
    public class ModulsController : Controller
    {
        IUnitOfWork unitOfWork;

        public ModulsController()
        {
            this.unitOfWork = new UnitOfWork<AbsenzenDBEntities>();
        }

        public ViewResult Index()
        {
            var modul = unitOfWork.GetRepository<Modul>().Get();
            return View(modul.ToList());
        }

        // GET: /Modul/Details/5
        public ViewResult Details(int id)
        {
            Modul modul = unitOfWork.GetRepository<Modul>().GetByID(id);
            return View(modul);
        }

        // GET: Modul/Create
        public ActionResult Create()
        {
            var module = unitOfWork.GetRepository<Modul>().Get();
            var lehrer = unitOfWork.GetRepository<Lehrer>().Get();

            ViewBag.lehrer_id = new SelectList(lehrer, "lehrer_id", "Nachname");       
            return View();
        }


        // POST: Modul/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
          [Bind(Include = "modul_id, Bezeichnung, lehrer_id")] Modul modul)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Modul>().Insert(modul);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateModulDropDownList(modul.modul_id);
            return View(modul);
        }

        // GET: /Modul/Edit/
        public ActionResult Edit(int id)
        {
            Modul module = unitOfWork.GetRepository<Modul>().GetByID(id);
            var lehrer = unitOfWork.GetRepository<Lehrer>().Get();

            ViewBag.lehrer_id = new SelectList(lehrer, "lehrer_id", "Nachname");

            PopulateModulDropDownList(module.modul_id);
            return View(module);
        }

        // POST: /Modul/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "modul_id, Bezeichnung, lehrer_id")] Modul modul)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Modul>().Update(modul);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateModulDropDownList(modul.modul_id);
            return View(modul);
        }

        // GET: /Modul/Delete/
        public ActionResult Delete(int id)
        {
            Modul modul = unitOfWork.GetRepository<Modul>().GetByID(id);
            return View(modul);
        }

        // POST: /Modul/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Modul course = unitOfWork.GetRepository<Modul>().GetByID(id);
            unitOfWork.GetRepository<Modul>().Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateModulDropDownList(object selectedModul = null)
        {
            var ModulQuery = unitOfWork.GetRepository<Modul>().Get(
                orderBy: q => q.OrderBy(d => d.modul_id));
            ViewBag.ModulID = new SelectList(ModulQuery, "modul_id", "modul_id", selectedModul);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
