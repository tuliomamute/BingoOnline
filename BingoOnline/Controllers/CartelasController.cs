using BingoOnline.Models;
using BingoOnline.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BingoOnline.Controllers
{
    public class CartelasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        /// <summary>
        /// Método responsável pela geração das cartelas
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Generate(int id)
        {
            if (db.Cartela.Where(x => x.BingoId == id).Count() == 100)
                return RedirectToAction("Index", "Bingos");

            List<List<int>> ListaCartelas = new List<List<int>>();
            GerarCartelas obj = null;

            //Execução Até Completar 100 Cartelas
            while (ListaCartelas.Count() != 100)
            {
                for (int i = 0; i < 100; i++)
                {
                    obj = new GerarCartelas();
                    ListaCartelas.Add(obj.RetornaListaCartelas());
                }
                //Distinct para retirar as Cartelas Duplicadas
                ListaCartelas = ListaCartelas.Distinct(new MultiSetComparer<int>()).ToList();
            }

            //Inclusão da Lista no Banco de Dados
            foreach (List<int> item in ListaCartelas)
            {
                db.Cartela.Add(new Cartela()
                {
                    BingoId = id,
                    NumerosCartela = Newtonsoft.Json.JsonConvert.SerializeObject(item)
                }
                );
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Bingos");
        }
    }
}