using CinemaDatabase.Core;
using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
            FilmShow = new FilmShowRepository(_context);
            Film = new FilmRepository(_context);
            Ticket = new TicketRepository(_context);
            Room = new RoomRepository(_context);


        }
        public IFilmShowRepository FilmShow { get; private set; }
        public IFilmRepository Film { get; private set; }
        public ITicketRepository Ticket { get; private set; }

        public IRoomRepository Room { get; private set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();

        }
    }
}
