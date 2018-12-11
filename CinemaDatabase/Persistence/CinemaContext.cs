using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase.Persistence
{
    public class CinemaContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmShow> FilmShows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public CinemaContext()
            : base("name=DefaultConnection")
        {

        }
    }
}
