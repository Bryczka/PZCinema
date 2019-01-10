using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FilmDetailedView : ContentPage
    {
        Film selectedFilm;
        //FilmShow selectedFilmShow;
        public FilmDetailedView(Film film)
        {

            InitializeComponent();
            selectedFilm = film;
            DetailedTitle.Text = film.Title;
            DetailedDuration.Text = "Duration (minutes) : " + film.Duration.ToString();
            DetailedAgeLimit.Text = "Age limit: " + film.Age_Limit.ToString();
            DetailedDescription.Text = "Description: " + System.Environment.NewLine + film.Description;

            LoadFilmShows();
        }

        protected override bool OnBackButtonPressed()
        {

            Application.Current.MainPage.Navigation.PopAsync();
            // If you want to continue going back
            base.OnBackButtonPressed();
            return false;

            // If you want to stop the back button
            //return true;

        }
        private async void LoadFilmShows()
        {

            var client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.0.102:9095/api/")
            };
            string responseString = "filmShows/" + selectedFilm.Id;
            HttpResponseMessage response = await client.GetAsync(responseString);
            var result = await response.Content.ReadAsStringAsync();

            List<FilmShow> ListFilmShow = new List<FilmShow>();
            ListFilmShow = JsonConvert.DeserializeObject<List<FilmShow>>(result);



            int i = 0;
            foreach (FilmShow filmshow in ListFilmShow)
            {
                Button button = new Button
                {
                    Margin = new Thickness(10, 10, 10, 10),
                    WidthRequest = 30,
                    HeightRequest = 80,
                    Text = "Name of room: " + filmshow.RoomName + "  Time: " + filmshow.Time,
                    FontSize = 15,
                    TextColor = Color.DarkSlateGray,
                    TabIndex = filmshow.Id

                };
                button.Clicked += new EventHandler(Button_Clicked);
                Layout.Children.Add(button);
                i++;
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int selectedFilmShowId = (sender as Button).TabIndex;
            string selectedFilmShow = (sender as Button).Text;
            Navigation.PushAsync(new TicketView(selectedFilm, selectedFilmShow, selectedFilmShowId));

        }
    }
}