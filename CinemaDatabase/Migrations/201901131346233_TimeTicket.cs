namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "ChooseTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "BuyTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "BuyTime");
            DropColumn("dbo.Tickets", "ChooseTime");
        }
    }
}
