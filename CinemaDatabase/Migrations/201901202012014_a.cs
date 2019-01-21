namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropColumn("dbo.Tickets", "User_Id");
            DropColumn("dbo.Users", "IsEmployee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsEmployee", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "User_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "User_Id");
            AddForeignKey("dbo.Tickets", "User_Id", "dbo.Users", "Id");
        }
    }
}
