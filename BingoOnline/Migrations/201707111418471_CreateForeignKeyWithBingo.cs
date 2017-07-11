namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateForeignKeyWithBingo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cartela", "BingoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Cartela", "BingoId");
            AddForeignKey("dbo.Cartela", "BingoId", "dbo.Bingo", "BingoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cartela", "BingoId", "dbo.Bingo");
            DropIndex("dbo.Cartela", new[] { "BingoId" });
            DropColumn("dbo.Cartela", "BingoId");
        }
    }
}
