using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;


namespace ClientCinemaApp
{
    public partial class MainPage : ContentPage
    {
        IpConfig ipConfig = new IpConfig();
        public MainPage()
        {
            InitializeComponent();
            DependencyService.Get<IMessage>().LongAlert("Connecting...");
            //Navigation.PushAsync(new RegisterPage());
        }

        private async void LoadFilms()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                    HttpResponseMessage response = await client.GetAsync("films");
                    var result = await response.Content.ReadAsStringAsync();
                    List<Film> ListFilms = new List<Film>();
                    ListFilms = JsonConvert.DeserializeObject<List<Film>>(result);
                    filmsListView.ItemsSource = ListFilms;
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    CheckConnection();
                }
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
