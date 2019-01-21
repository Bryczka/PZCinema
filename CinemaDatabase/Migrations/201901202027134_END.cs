namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class END : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Employees");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Employees", newName: "Users");
        }
    }
}
