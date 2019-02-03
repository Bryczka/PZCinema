using ClientCinemaApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Xamarin.Forms;


namespace ClientCinemaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<IMessage>().LongAlert("Connecting...");            
        }

        private async void LoadFilms()
        {
            
            List<Film> ListFilms = new List<Film>();
            ListFilms = await  ApiConnector.GetFilmListService();
            if (ListFilms != null)
            {            
                foreach (Film film in ListFilms)
                {
                    film.Poster = ImageSource.FromStream(() => new MemoryStream(film.FilmPoster));
                }
                filmsListView.ItemsSource = ListFilms;
            }
            else
            {
                CheckConnection();
            }
        }
        protected override void OnAppearing()
        {
            LoadFilms();
        }
        private void CheckConnection()
        {
            Navigation.PushAsync(new ChangeIpView());
        }

        private void FilmItemText_Tapped(object sender, EventArgs e)
        {
            Film selectedFilm = (Film)filmsListView.SelectedItem;
            Navigation.PushAsync(new FilmDetailedView(selectedFilm));
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AuthorView());
        }

        private void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuyData());
        }
    }
}
