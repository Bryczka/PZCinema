namespace CinemaDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Image : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "FilmPoster", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "FilmPoster");
        }
    }
}
