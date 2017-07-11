using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Bingo> Bingo { get; set; }
        public System.Data.Entity.DbSet<Cartela> Cartela { get; set; }
        public System.Data.Entity.DbSet<Premio> Premio { get; set; }

        public System.Data.Entity.DbSet<BingoOnline.Models.OrdemSorteio> OrdemSorteio{ get; set; }
    }
}