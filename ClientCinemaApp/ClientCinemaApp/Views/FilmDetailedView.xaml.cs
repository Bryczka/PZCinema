using ClientCinemaApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmDetailedView : ContentPage
    {
        Film selectedFilm;
        List<FilmShow> ListFilmShow = new List<FilmShow>();
        int selectedFilmShowId;
        public FilmDetailedView(Film film)
        {
            InitializeComponent();
            selectedFilm = film;
            DetailedTitle.Text = film.Title;
            DetailedDuration.Text = "Duration: " + film.Duration.ToString();
            DetailedAgeLimit.Text = "Age limit: " + film.Age_Limit.ToString();
            DetailedDescription.Text = "Description: " + Environment.NewLine + Environment.NewLine + film.Description;
            FilmPoster.Source = ImageSource.FromStream(() => new MemoryStream(film.FilmPoster));
            LoadFilmShows();
        }

        private async void LoadFilmShows()
        {
            ListFilmShow = await ApiConnector.GetFilmShowListService(selectedFilm.Id);
            if (ListFilmShow != null)
            {
                foreach (FilmShow filmshow in ListFilmShow)
                {
                    Button button = new Button
                    {
                        Margin = new Thickness(10, 10, 10, 10),
                        WidthRequest = 30,
                        HeightRequest = 80,
                        Text = "Name of room: " + filmshow.RoomName + Environment.NewLine +"Time: " + filmshow.Time,
                        FontSize = 15,
                        TabIndex = filmshow.Id,
                        BackgroundColor = Color.WhiteSmoke,
                    };
                    button.Clicked += new EventHandler(Button_Clicked);
                    Layout.Children.Add(button);
                }
            }
            else
            {
                await Navigation.PopAsync();
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            selectedFilmShowId = (sender as Button).TabIndex;
            FilmShow selectedFilmShow = ListFilmShow.Find(c => c.Id == (sender as Button).TabIndex);
            Navigation.PushAsync(new TicketView(selectedFilm, selectedFilmShow, selectedFilmShowId));
        }
    }
}