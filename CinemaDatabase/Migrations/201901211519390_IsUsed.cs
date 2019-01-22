namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsUsed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "IsUsed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsUsed");
        }
    }
}
