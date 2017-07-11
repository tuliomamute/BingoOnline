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
        [Key]
        public int OrdemSorteioBingoId { get; set; }
        [ForeignKey("BingoId")]
        public virtual Bingo Bingo { get; set; }
        public int BingoId { get; set; }
        [ForeignKey("PremioId")]
        public virtual Premio Premio { get; set; }
        public int PremioId { get; set; }
        public string Descricao { get; set; }
        public ICollection<OrdemSorteioCartelas> OrdemSorteioCartelas { get; set; }
    }
}