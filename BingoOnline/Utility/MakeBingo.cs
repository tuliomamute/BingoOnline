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
    public class MakeBingo
    {
        private ApplicationDbContext db;
        private List<int> UsedNumbers { get; set; }
        public MakeBingo(ApplicationDbContext db)
        {
            this.db = db;
            this.UsedNumbers = new List<int>();
        }

        public void GetResultFromBingo(int? SorteioId)
        {
            int number = 0;
            while (db.Sorteio.Where(x => x.QuantidadeAcertos == 15).Count() == 0)
            {
                number = NewNumber();
                var cartelas = db.Sorteio.Include(o => o.Cartela).Where(o => !string.IsNullOrEmpty(o.UserId)).ToList();

                //Deserializando o array de numeros, para validar se o numero sorteado está dentro dele
                foreach (var item in cartelas.Where(o => o.OrdemSorteioId == SorteioId).Where(x => JsonConvert.DeserializeObject<List<int>>(x.Cartela.NumerosCartela).Where(o => o == number).Count() > 0))
                {
                    //Somando na quantidade de acertos das cartelas
                    item.QuantidadeAcertos = item.QuantidadeAcertos + 1;
                    db.Entry(item).State = EntityState.Modified;
                }

                var Sorteio = db.OrdemSorteio.Find(SorteioId);

                Sorteio.Status = StatusEnum.Status.Realizado;
                db.Entry(Sorteio).State = EntityState.Modified;

                db.SaveChanges();
            }
        }

        private int NewNumber()
        {
            Random random = new Random();
            bool NumberUsed = false;

            int temp = 0;

            while (!NumberUsed)
            {
                temp = random.Next(1, 101);

                if (UsedNumbers.Where(x => x == temp).Count() > 0)
                    continue;

                UsedNumbers.Add(temp);
                NumberUsed = true;
            }

            return temp;
        }
    }
}