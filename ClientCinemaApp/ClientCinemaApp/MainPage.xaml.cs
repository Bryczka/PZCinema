using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;


namespace ClientCinemaApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            IpConfig ipConfig = new IpConfig();
            ipConfig.SetIp("192.168.0.105");

        }

        private async void LoadFilms()
        {
            IpConfig ipConfig = new IpConfig();



            try
            {

                string ip = "http://" + ipConfig.GetIpAsync() + ":9095/api/";
                var client = new HttpClient
                {
                    BaseAddress = new Uri(ip)
                };
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
            Navigation.PushAsync(new MyTicketsView());
        }
    }
}
