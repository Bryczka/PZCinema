namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowsAndColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rooms", "NumberOfRows", c => c.Int(nullable: false));
            AddColumn("dbo.Rooms", "NumberOfColumns", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rooms", "NumberOfColumns");
            DropColumn("dbo.Rooms", "NumberOfRows");
        }
    }
}
