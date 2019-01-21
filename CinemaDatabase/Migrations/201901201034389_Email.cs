namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "UserEmail");
        }
    }
}
