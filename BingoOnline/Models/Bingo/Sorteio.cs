using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    /// <summary>
    /// Tabela que armazena a Quantidade de Acertos de uma determinada cartela em um determinado sorteio
    /// </summary>
    public class Sorteio
    {
        [Key]
        public int SorteioId { get; set; }
        [ForeignKey("CartelaId")]
        public Cartela Cartela { get; set; }
        [ForeignKey("OrdemSorteioId")]
        public OrdemSorteio OrdemSorteio { get; set; }
        public int CartelaId { get; set; }
        public int OrdemSorteioId { get; set; }
        public int QuantidadeAcertos { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser Usuario { get; set; }
        public string UserId { get; set; }
    }
}