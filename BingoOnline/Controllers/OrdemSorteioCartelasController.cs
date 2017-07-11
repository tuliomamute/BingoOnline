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
    public class OrdemSorteioCartelasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Winners(int id, int bingoid)
        {
            var resultado = db.OrdemSorteioCartelas.Include(o => o.OrdemSorteio).Include(o => o.Usuario).Include(o => o.OrdemSorteio.Bingo);
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
    }
}