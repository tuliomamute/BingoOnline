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
    /// Tabela do Evento Bingo
    /// </summary>
    [Table("Bingo")]
    public class Bingo
    {

        public int BingoId { get; set; }
        [DisplayName("Descrição"), Required]
        public string Descricao { get; set; }
        [DisplayName("Status"), Required]
        public Status Status { get; set; }
        [DisplayName("Motivo Cancelamento")]
        public string MotivoCancelamento { get; set; }
        [DisplayName("Data Cancelamento"), Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataCancelamento { get; set; }
        [DisplayName("Data Criação"), Column(TypeName = "date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataCriacao { get; set; }
        [DisplayName("Data Realização"), Column(TypeName = "date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRealizacao { get; set; }
        public virtual ICollection<OrdemSorteio> OrdemSorteio { get; set; }
        public virtual ICollection<Cartela> Cartela { get; set; }

    }

}