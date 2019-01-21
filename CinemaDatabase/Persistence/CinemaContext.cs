using System.Data.Entity;

namespace CinemaDatabase.Persistence
{
    public class CinemaContext : DbContext
    {

        public CinemaContext()
    : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmShow> FilmShows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Employee> Employees { get; set; }


    }
}
