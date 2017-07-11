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
    public class BingosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bingos
        public ActionResult Index()
        {
            return View(db.Bingo.ToList());
        }

        // GET: Bingos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = db.Bingo.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            return View(bingo);
        }

        #region Create
        // GET: Bingos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bingos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BingoId,Descricao,Status,MotivoCancelamento,DataCancelamento,DataCriacao,DataRealizacao")] Bingo bingo)
        {
            if (ModelState.IsValid)
            {
                db.Bingo.Add(bingo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bingo);
        }
        #endregion

        #region Edit
        // GET: Bingos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = db.Bingo.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            return View(bingo);
        }

        // POST: Bingos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BingoId,Descricao,Status,MotivoCancelamento,DataCancelamento,DataCriacao,DataRealizacao")] Bingo bingo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bingo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bingo);
        }
        #endregion

        #region Delete
        // GET: Bingos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bingo bingo = db.Bingo.Find(id);
            if (bingo == null)
            {
                return HttpNotFound();
            }
            return View(bingo);
        }

        // POST: Bingos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bingo bingo = db.Bingo.Find(id);
            db.Bingo.Remove(bingo);
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
