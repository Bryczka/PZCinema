using CinemaDatabase.Persistence;


namespace CinemaDatabase
{


}
class Program
{
    static void Main(string[] args)
    {
        var context = new CinemaContext();
        UnitOfWork unitOfWork = new UnitOfWork(context);

    }
}

