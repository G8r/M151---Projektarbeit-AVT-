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
    public class LehrersController : Controller
    {
        IUnitOfWork unitOfWork;

        public LehrersController()
        {
            this.unitOfWork = new UnitOfWork<AbsenzenDBEntities>();
        }

        public ViewResult Index()
        {
            var lehrer = unitOfWork.GetRepository<Lehrer>().Get();
            return View(lehrer.ToList());
        }

        // GET: /Lehrer/Details/5
        public ViewResult Details(int id)
        {
            Lehrer lehrer = unitOfWork.GetRepository<Lehrer>().GetByID(id);
            return View(lehrer);
        }

        // GET: Lehrer/Create
        public ActionResult Create()
        {
            var lehrer = unitOfWork.GetRepository<Lehrer>();
            return View();
        }


        // POST: Lehrer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
          [Bind(Include = "lehrer_id, Vorname, Nachname")] Lehrer lehrer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Lehrer>().Insert(lehrer);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateLehrerDropDownList(lehrer.lehrer_id);
            return View(lehrer);
        }

        // GET: /Lehrer/Edit/
        public ActionResult Edit(int id)
        {
            Lehrer lehrer = unitOfWork.GetRepository<Lehrer>().GetByID(id);

            PopulateLehrerDropDownList(lehrer.lehrer_id);
            return View(lehrer);
        }

        // POST: /Lehrer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
             [Bind(Include = "lehrer_id, Vorname, Nachname")] Lehrer lehrer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.GetRepository<Lehrer>().Update(lehrer);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateLehrerDropDownList(lehrer.lehrer_id);
            return View(lehrer);
        }

        // GET: /Lehrer/Delete/
        public ActionResult Delete(int id)
        {
            Lehrer lehrer = unitOfWork.GetRepository<Lehrer>().GetByID(id);
            return View(lehrer);
        }

        // POST: /Lehrer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lehrer course = unitOfWork.GetRepository<Lehrer>().GetByID(id);
            unitOfWork.GetRepository<Lehrer>().Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        private void PopulateLehrerDropDownList(object selectedLehrer = null)
        {
            var LehrerenQuery = unitOfWork.GetRepository<Lehrer>().Get(
                orderBy: q => q.OrderBy(d => d.lehrer_id));
            ViewBag.LehrerID = new SelectList(LehrerenQuery, "lehrer_id", "lehrer_id", selectedLehrer);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
