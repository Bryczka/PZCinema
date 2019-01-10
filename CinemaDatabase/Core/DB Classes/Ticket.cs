using System.ComponentModel.DataAnnotations;

namespace CinemaDatabase
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        public FilmShow FilmShow { get; set; }
        public bool IsFree { get; set; }





    }
}
