using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        public FilmRepository(CinemaContext context) : base(context)
        {

        }

        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
