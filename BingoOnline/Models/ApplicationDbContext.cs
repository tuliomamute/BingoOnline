using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BingoOnline.Models
{
    /// <summary>
    /// Classe Responsável por geração de objeto de conexão com banco de dados
    /// </summary>
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

        #region MapeamentoBanco
        public System.Data.Entity.DbSet<Bingo> Bingo { get; set; }
        public System.Data.Entity.DbSet<Cartela> Cartela { get; set; }
        public System.Data.Entity.DbSet<Premio> Premio { get; set; }

        public System.Data.Entity.DbSet<BingoOnline.Models.OrdemSorteio> OrdemSorteio { get; set; }
        public System.Data.Entity.DbSet<BingoOnline.Models.Sorteio> Sorteio { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remoção dos deletes em cascata nas relação 1:N e N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}