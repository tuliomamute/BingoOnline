namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingStatsToLottery : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdemSorteio", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdemSorteio", "Status");
        }
    }
}
