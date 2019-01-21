namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PriceDefinition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "IsBought", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "IsBought");
        }
    }
}
