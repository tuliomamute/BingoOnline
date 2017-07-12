using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BingoOnline.Models;
using System.Data;
using System.Data.Entity;
using Newtonsoft.Json;

namespace BingoOnline.Utility
{
    public class RealizarBingo
    {
        private ApplicationDbContext db;
        private List<int> NumerosUsados { get; set; }
        public RealizarBingo(ApplicationDbContext db)
        {
            this.db = db;
            this.NumerosUsados = new List<int>();
        }

        /// <summary>
        /// Método responsável por realizar o sorteio do bingo (atualizando os usuários com quantidade de acertos)
        /// </summary>
        /// <param name="SorteioId"></param>
        public void RealizarSorteioBingo(int? SorteioId)
        {
            int number = 0;
            while (db.Sorteio.Where(x => x.QuantidadeAcertos == 15).Count() == 0)
            {
                number = NovoNumeroBingo();
                var cartelas = db.Sorteio.Include(o => o.Cartela).Where(o => !string.IsNullOrEmpty(o.UserId)).ToList();

                //Deserializando o array de numeros, para validar se o numero sorteado está dentro dele
                foreach (var item in cartelas.Where(o => o.OrdemSorteioId == SorteioId).Where(x => JsonConvert.DeserializeObject<List<int>>(x.Cartela.NumerosCartela).Where(o => o == number).Count() > 0))
                {
                    //Somando na quantidade de acertos das cartelas
                    item.QuantidadeAcertos = item.QuantidadeAcertos + 1;
                    db.Entry(item).State = EntityState.Modified;
                }

                db.SaveChanges();
            }

            OrdemSorteio Sorteio = db.OrdemSorteio.Find(SorteioId);

            Sorteio.Status = StatusEnum.Status.Realizado;
            db.Entry(Sorteio).State = EntityState.Modified;

            db.SaveChanges();
        }

        /// <summary>
        /// Gerar novo número para o sorteio
        /// </summary>
        /// <returns></returns>
        private int NovoNumeroBingo()
        {
            Random random = new Random();
            bool NumberoJaUtilizado = false;

            int temp = 0;

            while (!NumberoJaUtilizado)
            {
                temp = random.Next(1, 101);

                if (NumerosUsados.Where(x => x == temp).Count() > 0)
                    continue;

                NumerosUsados.Add(temp);
                NumberoJaUtilizado = true;
            }

            return temp;
        }
    }
}