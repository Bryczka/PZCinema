
using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class FilmShowRepository : Repository<FilmShow>, IFilmShowRepository
    {
        public FilmShowRepository(CinemaContext context) : base(context)
        {

        }
        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
