namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bingo", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.OrdemSorteio", "Descricao", c => c.String(nullable: false));
            AlterColumn("dbo.Premio", "NomePremio", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Premio", "NomePremio", c => c.String());
            AlterColumn("dbo.OrdemSorteio", "Descricao", c => c.String());
            AlterColumn("dbo.Bingo", "Descricao", c => c.String());
        }
    }
}
