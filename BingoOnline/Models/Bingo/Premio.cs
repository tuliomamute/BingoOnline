using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    /// <summary>
    /// Tabela que armazena os Prêmios
    /// </summary>
    [Table("Premio")]
    public class Premio
    {
        public int PremioId { get; set; }
        [DisplayName("Nome Prêmio")]
        public string NomePremio { get; set; }
        [DisplayName("Valor Prêmio"), DataType(DataType.Currency)]
        public float ValorPremio { get; set; }
        public ICollection<OrdemSorteio> OrdemSorteioBingo { get; set; }
    }
}