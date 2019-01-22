using CinemaDatabase.Core.Repositories;
using System;

namespace CinemaDatabase.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IFilmShowRepository FilmShow { get; }
        IFilmRepository Film { get;  }
        ITicketRepository Ticket { get; }
        IRoomRepository Room { get; }
        IPriceRepository Price { get; }
        IEmployeeRepository Employee { get; }
        int Complete();
    }
}
