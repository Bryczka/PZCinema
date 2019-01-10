using CinemaDatabase.Core.Repositories;

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
