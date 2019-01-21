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
        IpConfig ipConfig = new IpConfig();
        Film selectedFilm;
        List<FilmShow> ListFilmShow = new List<FilmShow>();
        int selectedFilmShowId;
        public FilmDetailedView(Film film)
        {

            InitializeComponent();
            selectedFilm = film;
            DetailedTitle.Text = film.Title;
            DetailedDuration.Text = "Duration (minutes) : " + film.Duration.ToString();
            DetailedAgeLimit.Text = "Age limit: " + film.Age_Limit.ToString();
            DetailedDescription.Text = "Description: " + Environment.NewLine + film.Description;
            LoadFilmShows();
        }

        private async void LoadFilmShows()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "filmShows/" + selectedFilm.Id;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    ListFilmShow = JsonConvert.DeserializeObject<List<FilmShow>>(result);

                    foreach (FilmShow filmshow in ListFilmShow)
                    {
                        Button button = new Button
                        {
                            Margin = new Thickness(10, 10, 10, 10),
                            WidthRequest = 30,
                            HeightRequest = 80,
                            Text = "Name of room: " + filmshow.RoomName + "  Time: " + filmshow.Time,
                            FontSize = 15,
                            TabIndex = filmshow.Id,
                            BackgroundColor = Color.WhiteSmoke,
                        };
                        button.Clicked += new EventHandler(Button_Clicked);
                        Layout.Children.Add(button);
                    }
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    await Navigation.PopAsync();
                }
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