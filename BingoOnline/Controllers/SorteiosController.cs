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
    public class SorteiosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Recuperação dos dados para exibição da tela de Vencedores
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bingoid"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Exibição da tela que permite ao usuário participar de um bingo
        /// </summary>
        /// <returns></returns>
        public ActionResult Associate()
        {
            return View(db.Bingo.ToList());
        }

        /// <summary>
        /// Associação do usuário a todos os sorteios de um determinado bingo
        /// </summary>
        /// <param name="BingoId"></param>
        /// <returns></returns>
        public ActionResult Participate(int BingoId)
        {
            //Contador de identificador de cartela
            int cartela = 0;
            
            //Lista de Sorteios de um determinado bingo
            var sorteiosbingo = db.OrdemSorteio.Where(x => x.BingoId == BingoId).ToList();
            
            //Recuperação da primeira cartela
            var cartelas = db.Cartela.Where(x => x.BingoId == BingoId).OrderBy(x => x.CartelaId).ToList().FirstOrDefault();

            //Recuperando a ultima cartela utilizada
            var sorteios = db.Sorteio.Where(x => x.OrdemSorteio.BingoId == BingoId).OrderByDescending(x => x.CartelaId).FirstOrDefault();

            var UserGuid = User.Identity.GetUserId();

            //Percorre todos os sorteios do bingo
            foreach (var item in sorteiosbingo)
            {
                if (db.Sorteio.Where(x => x.OrdemSorteioId == item.OrdemSorteioBingoId).Count() == 100)
                    continue;

                if (db.Sorteio.Where(x => x.UserId == UserGuid && x.OrdemSorteioId == item.OrdemSorteioBingoId).Count() > 0)
                    continue;

                if (sorteios != null)
                    cartela = sorteios.CartelaId + 1;
                else
                    cartela = cartelas.CartelaId;

                Sorteio associacaousuarios = new Sorteio();

                associacaousuarios.OrdemSorteioId = item.OrdemSorteioBingoId;
                associacaousuarios.QuantidadeAcertos = 0;
                associacaousuarios.UserId = UserGuid;
                associacaousuarios.CartelaId = cartela;

                //Relaciona o Jogador aos sorteios de um determinado bingo
                db.Sorteio.Add(associacaousuarios);
            }

            db.SaveChanges();
            return RedirectToAction("Associate", new { BingoId = BingoId });
        }
    }
}