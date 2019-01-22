using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        public RoomRepository(CinemaContext context) : base(context)
        {

        }
        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
