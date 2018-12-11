using CinemaDatabase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmShowRepository FilmShow { get; }
        

        int Complete();
    }
}
