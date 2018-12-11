using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase
{
    public class FilmShow
    {
        public int Id { get; set; }
        public string Time { get; set; }

        public string RoomName { get; set; }
        public Film Film { get; set; }
        public IList<Ticket> Tickets { get; set; }

        


    }
}
