using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoOnline.Utility
{
    public class GerarCartelas
    {
        /// <summary>
        /// Geração da Lista de Cartelas para um Determinado Bingo
        /// </summary>
        /// <returns></returns>
        public List<int> RetornaListaCartelas()
        {
            List<int> NumerosUtilizados = new List<int>();
            List<int> ListaRetorno = new List<int>();
            int temp = 0;
            Random random = new Random();

            try
            {

                while (ListaRetorno.Count != 15)
                {
                    temp = random.Next(1, 101);

                    //Se o número gerado já tiver sido utilizado, continuar a execução para ser gerado outro numero
                    if (NumerosUtilizados.Contains(temp))
                        continue;

                    NumerosUtilizados.Add(temp);
                    ListaRetorno.Add(temp);
                }

                ListaRetorno = ListaRetorno.OrderBy(x => x).ToList();
                return ListaRetorno;
            }
            finally
            {
                if (ListaRetorno != null)
                    ListaRetorno = null;

                if (NumerosUtilizados != null)
                    NumerosUtilizados = null;

                if (random != null)
                    random = null;
            }
        }
    }
}