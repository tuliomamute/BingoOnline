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

        public ActionResult Winners(int id)
        {
            var resultado = db.OrdemSorteioCartelas.Include(o => o.OrdemSorteio).Include(o => o.Usuario).Include(o => o.OrdemSorteio.Bingo);
            var resultadofinal = resultado.Where(x => x.QuantidadeAcertos == 15);
            return View(resultadofinal);
        }
    }
}