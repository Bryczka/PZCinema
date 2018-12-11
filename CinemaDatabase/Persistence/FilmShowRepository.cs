
using CinemaDatabase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CinemaDatabase.Persistence
{
    public class FilmShowRepository : Repository<FilmShow>, IFilmShowRepository
    {
        public FilmShowRepository(CinemaContext context) : base(context)
        {

        }

       

        IEnumerable<FilmShow> IFilmShowRepository.GetOccupiedSeats()
        {   //PlutoContext.Authors.Include(a => a.Courses).SingleOrDefault(a => a.Id == id);
            throw new NotImplementedException();
            


        }

        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
