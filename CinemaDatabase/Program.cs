using CinemaDatabase;
using CinemaDatabase.Core;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CinemaDatabase
{

    
    }
    class Program
    {
        static void Main(string[] args)
        {
        using (var unitOfWork = new UnitOfWork(new CinemaContext()))
        {
            var context = new CinemaContext();
            /*var film = new Film
            {
                Title = "Fast and Forous",
                Age_Limit = 15,
                Duration = 150,
                Description = "About car racing!"
            };*/
            //var film = unitOfWork.Film.Get(4);
            //Console.WriteLine(film.Name);

            //unitOfWork.Film.Add(film);
            //unitOfWork.Complete();
            //var wolne = context.Seats.Where(c => c.Occupied == true && c.Room);
            //foreach (var seat in wolne)
            //Console.WriteLine(seat.Id); 
            
            Console.WriteLine(unitOfWork.FilmShow.GetOccupiedSeats().ToString());
            //Console.ReadKey();
            //Console.ReadKey();
        }
       
        }
    }

