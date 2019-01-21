namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.Int(nullable: false),
                        Password = c.String(),
                        IsEmployee = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "User_Id", c => c.Int());
            CreateIndex("dbo.Tickets", "User_Id");
            AddForeignKey("dbo.Tickets", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropColumn("dbo.Tickets", "User_Id");
            DropTable("dbo.Users");
        }
    }
}
