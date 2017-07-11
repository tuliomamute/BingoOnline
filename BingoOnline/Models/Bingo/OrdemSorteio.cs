using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    [Table("OrdemSorteio")]
    public class OrdemSorteio
    {
        [Key, Column(Order = 0)]
        public int OrdemSorteioBingoId { get; set; }
        [Key, Column(Order = 1), ForeignKey("BingoId")]
        public virtual Bingo Bingo { get; set; }
        public int BingoId { get; set; }
        [Key, Column(Order = 2), ForeignKey("PremioId")]
        public virtual Premio Premio { get; set; }
        public int PremioId { get; set; }
        public string Descricao { get; set; }
    }
}