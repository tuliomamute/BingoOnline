namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableNameOrdemSorteio : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.OrdemSorteioBingo", newName: "OrdemSorteio");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OrdemSorteio", newName: "OrdemSorteioBingo");
        }
    }
}
