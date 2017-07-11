namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTypes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bingo", "DataCancelamento", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.Bingo", "DataCriacao", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Bingo", "DataRealizacao", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bingo", "DataRealizacao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bingo", "DataCriacao", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bingo", "DataCancelamento", c => c.DateTime());
        }
    }
}
