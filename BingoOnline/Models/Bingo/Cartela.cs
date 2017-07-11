using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    [Table("Cartela")]

    public class Cartela
    {
        public int CartelaId { get; set; }
        public string NumerosCartela { get; set; }
        [ForeignKey("BingoId")]
        public virtual Bingo Bingo { get; set; }
        public int BingoId { get; set; }
        public ICollection<OrdemSorteioCartelas> OrdemSorteioCartelas { get; set; }

    }
}