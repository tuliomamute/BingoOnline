using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static BingoOnline.Utility.StatusEnum;

namespace BingoOnline.Models
{
    /// <summary>
    /// Tabela que armazena o que será sorteado por evento
    /// </summary>
    [Table("OrdemSorteio")]
    public class OrdemSorteio
    {
        [Key]
        public int OrdemSorteioBingoId { get; set; }
        [ForeignKey("BingoId"), DisplayName("Bingo")]
        public virtual Bingo Bingo { get; set; }
        [DisplayName("Bingo"), Required]
        public int BingoId { get; set; }
        [ForeignKey("PremioId"), DisplayName("Prêmio")]
        public virtual Premio Premio { get; set; }
        [DisplayName("Prêmio"), Required]
        public int PremioId { get; set; }
        [DisplayName("Descrição"), Required]
        public string Descricao { get; set; }
        [DisplayName("Status"), Required]
        public Status Status { get; set; }
        public ICollection<Sorteio> Sorteio { get; set; }
    }
}