using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }

        [Index(IsUnique=true)]
        public int SeatNumber { get; set; }

        public FilmShow FilmShow { get; set; }

        
    }
}
