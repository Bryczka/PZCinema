using CinemaDatabase.Core.Repositories;
using System;

namespace CinemaDatabase.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmShowRepository FilmShow { get; }
        int Complete();
    }
}
