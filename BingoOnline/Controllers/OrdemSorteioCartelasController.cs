using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BingoOnline.Models;
using Microsoft.AspNet.Identity;

namespace BingoOnline.Controllers
{
    public class OrdemSorteioCartelasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Winners(int id, int bingoid)
        {
            var resultado = db.Sorteio.Include(o => o.OrdemSorteio).Include(o => o.Usuario).Include(o => o.OrdemSorteio.Bingo);
            var resultadofinal = resultado.Where(x => x.QuantidadeAcertos == 15 && x.OrdemSorteioId == id).ToList();

            if (resultadofinal.Count() == 0)
            {
                ViewBag.Premio = db.OrdemSorteio.Where(x => x.OrdemSorteioBingoId == id).FirstOrDefault().Descricao;
                ViewBag.Bingo = db.Bingo.Where(x => x.BingoId == bingoid).FirstOrDefault().Descricao;
                ViewBag.BingoId = bingoid;
            }
            else
            {
                ViewBag.Premio = resultadofinal.ElementAt(0).OrdemSorteio.Descricao;
                ViewBag.Bingo = resultadofinal.ElementAt(0).OrdemSorteio.Bingo.Descricao;
                ViewBag.BingoId = bingoid;
            }

            return View(resultadofinal);

        }

        public ActionResult Associate()
        {
            return View(db.Bingo.ToList());
        }

        public ActionResult Participate(int BingoId)
        {
            int cartela = 0;
            var sorteiosbingo = db.OrdemSorteio.Where(x => x.BingoId == BingoId).ToList();
            var cartelas = db.Cartela.Where(x => x.BingoId == BingoId).OrderBy(x => x.CartelaId).ToList();
            var sorteios = db.Sorteio.Where(x => x.OrdemSorteio.BingoId == BingoId).OrderByDescending(x => x.CartelaId).FirstOrDefault();

            var UserGuid = User.Identity.GetUserId();

            foreach (var item in sorteiosbingo)
            {
                if (db.Sorteio.Where(x => x.OrdemSorteioId == item.OrdemSorteioBingoId).Count() == 100)
                    continue;

                if (db.Sorteio.Where(x => x.UserId == UserGuid && x.OrdemSorteioId == item.OrdemSorteioBingoId).Count() > 0)
                    continue;

                if (sorteios != null)
                    cartela = sorteios.CartelaId + 1;
                else
                    cartela = cartelas.FirstOrDefault().CartelaId;

                Sorteio associacaousuarios = new Sorteio();

                associacaousuarios.OrdemSorteioId = item.OrdemSorteioBingoId;
                associacaousuarios.QuantidadeAcertos = 0;
                associacaousuarios.UserId = UserGuid;
                associacaousuarios.CartelaId = cartela;

                db.Sorteio.Add(associacaousuarios);
            }

            db.SaveChanges();
            return RedirectToAction("Associate", new { BingoId = BingoId });
        }
    }
}