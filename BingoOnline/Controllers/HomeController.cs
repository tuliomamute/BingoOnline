using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BingoOnline.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Exibição de Tela Inicial
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}