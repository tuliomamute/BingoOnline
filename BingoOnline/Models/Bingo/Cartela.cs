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
    }
}