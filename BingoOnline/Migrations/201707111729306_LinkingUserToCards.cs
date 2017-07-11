namespace BingoOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkingUserToCards : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdemSorteioCartelas", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.OrdemSorteioCartelas", "UserId");
            AddForeignKey("dbo.OrdemSorteioCartelas", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrdemSorteioCartelas", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.OrdemSorteioCartelas", new[] { "UserId" });
            DropColumn("dbo.OrdemSorteioCartelas", "UserId");
        }
    }
}
