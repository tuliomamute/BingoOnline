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

        // GET: Cartelas
        public ActionResult Generate(int id)
        {
            if (db.Cartela.Where(x => x.BingoId == id).Count() == 100)
                return RedirectToAction("Index", "Bingos");

            List<List<int>> ListaCartelas = new List<List<int>>();
            GenerateCards obj = null;

            while (ListaCartelas.Count() != 100)
            {
                for (int i = 0; i < 100; i++)
                {
                    obj = new GenerateCards();
                    ListaCartelas.Add(obj.ReturnCardsArray());
                }

                ListaCartelas = ListaCartelas.Distinct(new MultiSetComparer<int>()).ToList();
            }

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