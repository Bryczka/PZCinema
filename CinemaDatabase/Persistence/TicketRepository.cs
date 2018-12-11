using CinemaDatabase.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase.Persistence
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(CinemaContext context) : base(context)
        {

        }

        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
