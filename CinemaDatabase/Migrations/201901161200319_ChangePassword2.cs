namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePassword2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Password", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
        }
    }
}
