namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeDataCancelamento : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bingo", "DataCancelamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bingo", "DataCancelamento", c => c.DateTime(nullable: false));
        }
    }
}
