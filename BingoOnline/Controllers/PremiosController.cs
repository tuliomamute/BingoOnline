using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BingoOnline.Models;

namespace BingoOnline.Controllers
{
    public class PremiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Premios
        public ActionResult Index()
        {
            return View(db.Premio.ToList());
        }

        // GET: Premios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premio premio = db.Premio.Find(id);
            if (premio == null)
            {
                return HttpNotFound();
            }
            return View(premio);
        }

        #region Create

        // GET: Premios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Premios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Premio premio)
        {
            if (ModelState.IsValid)
            {
                db.Premio.Add(premio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(premio);
        }
        #endregion

        #region Edit
        // GET: Premios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premio premio = db.Premio.Find(id);
            if (premio == null)
            {
                return HttpNotFound();
            }
            return View(premio);
        }

        // POST: Premios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PremioId,NomePremio,ValorPremio")] Premio premio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(premio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(premio);
        }
        #endregion

        #region Delete

        // GET: Premios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Premio premio = db.Premio.Find(id);
            if (premio == null)
            {
                return HttpNotFound();
            }
            return View(premio);
        }

        // POST: Premios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Premio premio = db.Premio.Find(id);
            db.Premio.Remove(premio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

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
