namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilmShows", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Tickets", "FilmShow_Id", "dbo.FilmShows");
            DropIndex("dbo.FilmShows", new[] { "Film_Id" });
            DropIndex("dbo.Tickets", new[] { "FilmShow_Id" });
            RenameColumn(table: "dbo.FilmShows", name: "Film_Id", newName: "FilmId");
            RenameColumn(table: "dbo.Tickets", name: "FilmShow_Id", newName: "FilmShowId");
            AlterColumn("dbo.FilmShows", "FilmId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "FilmShowId", c => c.Int(nullable: false));
            CreateIndex("dbo.FilmShows", "FilmId");
            CreateIndex("dbo.Tickets", "FilmShowId");
            AddForeignKey("dbo.FilmShows", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "FilmShowId", "dbo.FilmShows", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "FilmShowId", "dbo.FilmShows");
            DropForeignKey("dbo.FilmShows", "FilmId", "dbo.Films");
            DropIndex("dbo.Tickets", new[] { "FilmShowId" });
            DropIndex("dbo.FilmShows", new[] { "FilmId" });
            AlterColumn("dbo.Tickets", "FilmShowId", c => c.Int());
            AlterColumn("dbo.FilmShows", "FilmId", c => c.Int());
            RenameColumn(table: "dbo.Tickets", name: "FilmShowId", newName: "FilmShow_Id");
            RenameColumn(table: "dbo.FilmShows", name: "FilmId", newName: "Film_Id");
            CreateIndex("dbo.Tickets", "FilmShow_Id");
            CreateIndex("dbo.FilmShows", "Film_Id");
            AddForeignKey("dbo.Tickets", "FilmShow_Id", "dbo.FilmShows", "Id");
            AddForeignKey("dbo.FilmShows", "Film_Id", "dbo.Films", "Id");
        }
    }
}
