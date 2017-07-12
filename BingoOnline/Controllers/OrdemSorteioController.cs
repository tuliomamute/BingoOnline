using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BingoOnline.Models;
using BingoOnline.Utility;

namespace BingoOnline.Controllers
{
    public class OrdemSorteioController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Retorna Listagem de sorteios de um determinado bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            ViewBag.BingoId = id;

            var ordemSorteioBingos = db.OrdemSorteio.Include(o => o.Bingo).Include(o => o.Premio);
            return View(ordemSorteioBingos.Where(x => x.BingoId == id).ToList());
        }

        /// <summary>
        /// Retorno de Detalhes de um sorteio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método de realização de sorteio
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Draw(int? id)
        {
            RealizarBingo bingo = new RealizarBingo(db);

            bingo.RealizarSorteioBingo(id);

            return RedirectToAction("Index", "Bingos");
        }

        #region Create

        /// <summary>
        /// Exibição da tela de criação de um sorteio associado a um bingo
        /// </summary>
        /// <param name="BingoId"></param>
        /// <returns></returns>
        public ActionResult Create(int BingoId)
        {
            ViewBag.BingoId = new SelectList(db.Bingo, "BingoId", "Descricao", BingoId);
            ViewBag.PremioId = new SelectList(db.Premio, "PremioId", "NomePremio");
            return View();
        }

        /// <summary>
        /// Criação de um sorteio associado a um bingo
        /// </summary>
        /// <param name="ordemSorteioBingo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Exibição da tela de um sorteio associado a um bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualização de um sorteio associado a um bingo
        /// </summary>
        /// <param name="ordemSorteioBingo"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Exibição da tela de exclusão de sorteio associado a um bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Confirmação de Exclusão de um sorteio associado a um bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
