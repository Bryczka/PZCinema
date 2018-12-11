using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaDatabase
{
    public class Film
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public int Age_Limit { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public IList<FilmShow> FilmShows { get; set; }
        
    }
}
