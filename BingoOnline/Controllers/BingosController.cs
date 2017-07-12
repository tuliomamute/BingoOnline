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

        /// <summary>
        /// Retorna Lista de Bingos
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(db.Bingo.ToList());
        }

        /// <summary>
        /// Retorna os Detalhes do Bingo Escolhido
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Retorna Tela de Criação de Bingo
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por criar o Bingo na base
        /// </summary>
        /// <param name="bingo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Metodo que retorna Tela de Edição do Bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que Salva o registro editado na base
        /// </summary>
        /// <param name="bingo"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Método que retorna a tela de Exclusão
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que confirma a exclusão do bingo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
