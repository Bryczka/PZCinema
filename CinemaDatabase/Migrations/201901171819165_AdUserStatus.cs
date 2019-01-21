namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdUserStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsLogged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsLogged");
        }
    }
}
