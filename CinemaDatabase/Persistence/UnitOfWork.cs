using CinemaDatabase.Core;
using CinemaDatabase.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           
           
        }
        public IFilmShowRepository FilmShow { get; private set; }
        public IFilmRepository Film { get; private set; }
        public ITicketRepository Ticket { get; private set; }




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
