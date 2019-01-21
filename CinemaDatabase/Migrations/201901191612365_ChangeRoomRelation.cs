namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FilmShows", "Room_Id", c => c.Int());
            CreateIndex("dbo.FilmShows", "Room_Id");
            AddForeignKey("dbo.FilmShows", "Room_Id", "dbo.Rooms", "Id");
            DropColumn("dbo.Users", "IsLogged");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "IsLogged", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.FilmShows", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.FilmShows", new[] { "Room_Id" });
            DropColumn("dbo.FilmShows", "Room_Id");
        }
    }
}
