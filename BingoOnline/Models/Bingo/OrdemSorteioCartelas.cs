using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class OrdemSorteioCartelas
    {
        [Key]
        public int OrdemSorteioCartelasId { get; set; }
        [ForeignKey("CartelaId")]
        public Cartela Cartela { get; set; }
        [ForeignKey("OrdemSorteioId")]
        public OrdemSorteio OrdemSorteio { get; set; }
        public int CartelaId { get; set; }
        public int OrdemSorteioId { get; set; }
        public int QuantidadeAcertos { get; set; }
    }
}