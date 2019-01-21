namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRoomRelation1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmShows", "Room_Id", "dbo.Rooms");
            DropIndex("dbo.FilmShows", new[] { "Room_Id" });
            RenameColumn(table: "dbo.FilmShows", name: "Room_Id", newName: "RoomId");
            AlterColumn("dbo.FilmShows", "RoomId", c => c.Int(nullable: false));
            CreateIndex("dbo.FilmShows", "RoomId");
            AddForeignKey("dbo.FilmShows", "RoomId", "dbo.Rooms", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FilmShows", "RoomId", "dbo.Rooms");
            DropIndex("dbo.FilmShows", new[] { "RoomId" });
            AlterColumn("dbo.FilmShows", "RoomId", c => c.Int());
            RenameColumn(table: "dbo.FilmShows", name: "RoomId", newName: "Room_Id");
            CreateIndex("dbo.FilmShows", "Room_Id");
            AddForeignKey("dbo.FilmShows", "Room_Id", "dbo.Rooms", "Id");
        }
    }
}
