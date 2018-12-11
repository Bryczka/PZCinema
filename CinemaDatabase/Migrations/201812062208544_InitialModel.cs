namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Age_Limit = c.Int(nullable: false),
                        Duration = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmShows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time = c.String(),
                        RoomName = c.String(),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Price = c.Double(nullable: false),
                        SeatNumber = c.Int(nullable: false),
                        FilmShow_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FilmShows", t => t.FilmShow_Id)
                .Index(t => t.SeatNumber, unique: true)
                .Index(t => t.FilmShow_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "FilmShow_Id", "dbo.FilmShows");
            DropForeignKey("dbo.FilmShows", "Film_Id", "dbo.Films");
            DropIndex("dbo.Tickets", new[] { "FilmShow_Id" });
            DropIndex("dbo.Tickets", new[] { "SeatNumber" });
            DropIndex("dbo.FilmShows", new[] { "Film_Id" });
            DropTable("dbo.Tickets");
            DropTable("dbo.FilmShows");
            DropTable("dbo.Films");
        }
    }
}
