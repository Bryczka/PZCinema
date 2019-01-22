using CinemaDatabase.Core.Repositories;

namespace CinemaDatabase.Persistence
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CinemaContext context) : base(context)
        {

        }
        public CinemaContext CinemaContext
        {
            get { return Context as CinemaContext; }
        }
    }
}
