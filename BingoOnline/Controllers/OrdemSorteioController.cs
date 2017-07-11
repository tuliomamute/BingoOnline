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
    public class OrdemSorteioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrdemSorteioBingos
        public ActionResult Index(int id)
        {
            ViewBag.BingoId = id;

            var ordemSorteioBingos = db.OrdemSorteio.Include(o => o.Bingo).Include(o => o.Premio);
            return View(ordemSorteioBingos.Where(x => x.BingoId == id).ToList());
        }

        // GET: OrdemSorteioBingos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemSorteio ordemSorteioBingo = db.OrdemSorteio.Find(id);
            if (ordemSorteioBingo == null)
            {
                return HttpNotFound();
            }
            return View(ordemSorteioBingo);
        }

        #region Create

        // GET: OrdemSorteioBingos/Create
        public ActionResult Create(int BingoId)
        {
            ViewBag.BingoId = new SelectList(db.Bingo, "BingoId", "Descricao", BingoId);
            ViewBag.PremioId = new SelectList(db.Premio, "PremioId", "NomePremio");
            return View();
        }

        // POST: OrdemSorteioBingos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdemSorteio ordemSorteioBingo)
        {
            if (ModelState.IsValid)
            {
                db.OrdemSorteio.Add(ordemSorteioBingo);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = ordemSorteioBingo.BingoId });
            }

            ViewBag.BingoId = new SelectList(db.Bingo, "BingoId", "Descricao", ordemSorteioBingo.BingoId);
            ViewBag.PremioId = new SelectList(db.Premio, "PremioId", "NomePremio", ordemSorteioBingo.PremioId);
            return View(ordemSorteioBingo);
        }
        #endregion

        #region Edit

        // GET: OrdemSorteioBingos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemSorteio ordemSorteioBingo = db.OrdemSorteio.Find(id);
            if (ordemSorteioBingo == null)
            {
                return HttpNotFound();
            }
            ViewBag.BingoId = new SelectList(db.Bingo, "BingoId", "Descricao", ordemSorteioBingo.BingoId);
            ViewBag.PremioId = new SelectList(db.Premio, "PremioId", "NomePremio", ordemSorteioBingo.PremioId);
            return View(ordemSorteioBingo);
        }

        // POST: OrdemSorteioBingos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdemSorteio ordemSorteioBingo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemSorteioBingo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BingoId = new SelectList(db.Bingo, "BingoId", "Descricao", ordemSorteioBingo.BingoId);
            ViewBag.PremioId = new SelectList(db.Premio, "PremioId", "NomePremio", ordemSorteioBingo.PremioId);
            return View(ordemSorteioBingo);
        }
        #endregion

        #region Delete

        // GET: OrdemSorteioBingos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemSorteio ordemSorteioBingo = db.OrdemSorteio.Find(id);
            if (ordemSorteioBingo == null)
            {
                return HttpNotFound();
            }
            return View(ordemSorteioBingo);
        }

        // POST: OrdemSorteioBingos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemSorteio ordemSorteioBingo = db.OrdemSorteio.Find(id);
            db.OrdemSorteio.Remove(ordemSorteioBingo);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = ordemSorteioBingo.BingoId });
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
