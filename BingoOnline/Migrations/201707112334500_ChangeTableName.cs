namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableName : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrdemSorteioCartelas", "CartelaId", "dbo.Cartela");
            DropForeignKey("dbo.OrdemSorteioCartelas", "OrdemSorteioId", "dbo.OrdemSorteio");
            DropForeignKey("dbo.OrdemSorteioCartelas", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OrdemSorteioCartelas", new[] { "CartelaId" });
            DropIndex("dbo.OrdemSorteioCartelas", new[] { "OrdemSorteioId" });
            DropIndex("dbo.OrdemSorteioCartelas", new[] { "UserId" });
            CreateTable(
                "dbo.Sorteios",
                c => new
                    {
                        SorteioId = c.Int(nullable: false, identity: true),
                        CartelaId = c.Int(nullable: false),
                        OrdemSorteioId = c.Int(nullable: false),
                        QuantidadeAcertos = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SorteioId)
                .ForeignKey("dbo.Cartela", t => t.CartelaId)
                .ForeignKey("dbo.OrdemSorteio", t => t.OrdemSorteioId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CartelaId)
                .Index(t => t.OrdemSorteioId)
                .Index(t => t.UserId);
            
            DropTable("dbo.OrdemSorteioCartelas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrdemSorteioCartelas",
                c => new
                    {
                        OrdemSorteioCartelasId = c.Int(nullable: false, identity: true),
                        CartelaId = c.Int(nullable: false),
                        OrdemSorteioId = c.Int(nullable: false),
                        QuantidadeAcertos = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrdemSorteioCartelasId);
            
            DropForeignKey("dbo.Sorteios", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sorteios", "OrdemSorteioId", "dbo.OrdemSorteio");
            DropForeignKey("dbo.Sorteios", "CartelaId", "dbo.Cartela");
            DropIndex("dbo.Sorteios", new[] { "UserId" });
            DropIndex("dbo.Sorteios", new[] { "OrdemSorteioId" });
            DropIndex("dbo.Sorteios", new[] { "CartelaId" });
            DropTable("dbo.Sorteios");
            CreateIndex("dbo.OrdemSorteioCartelas", "UserId");
            CreateIndex("dbo.OrdemSorteioCartelas", "OrdemSorteioId");
            CreateIndex("dbo.OrdemSorteioCartelas", "CartelaId");
            AddForeignKey("dbo.OrdemSorteioCartelas", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.OrdemSorteioCartelas", "OrdemSorteioId", "dbo.OrdemSorteio", "OrdemSorteioBingoId");
            AddForeignKey("dbo.OrdemSorteioCartelas", "CartelaId", "dbo.Cartela", "CartelaId");
        }
    }
}
