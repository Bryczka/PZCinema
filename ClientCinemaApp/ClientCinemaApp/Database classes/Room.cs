using System.Collections.Generic;

namespace ClientCinemaApp
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfColumns { get; set; }

        public IList<FilmShow> FilmShow { get; set; }
    }

    
}
