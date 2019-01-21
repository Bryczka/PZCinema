using System.Collections.Generic;

namespace ClientCinemaApp
{
    public class FilmShow
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public int NumberOfSeats { get; set; }
        public Film Film { get; set; }
        public IList<Ticket> Tickets { get; set; }
        public int FilmId { get; set; }

    }
}

