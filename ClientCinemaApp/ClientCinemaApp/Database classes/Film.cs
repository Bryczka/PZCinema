using System.Collections.Generic;
using Xamarin.Forms;

namespace ClientCinemaApp
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Age_Limit { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public byte[] FilmPoster { get; set; }
        public ImageSource Poster { get; set; }
        public IList<FilmShow> FilmShows { get; set; }
    }
}
