using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class PriceRepository : Repository<Price>, IPriceRepository
    {
        public PriceRepository(CinemaContext context) : base(context)
        {

        }

        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
