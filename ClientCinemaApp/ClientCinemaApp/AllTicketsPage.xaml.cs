using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTicketsPage : ContentPage
    {
        FilmShow selectedTicketFilmShow = new FilmShow();
        Film selectedTicketFilm = new Film();
        List<Ticket> ListTickets = new List<Ticket>();
        string userEmail;
        IpConfig ipConfig = new IpConfig();
        public AllTicketsPage(string email)
        {
            InitializeComponent();
            userEmail = email;
            GetTickets();

        }
        private void SetPicker()
        {
            try
            {
                ticketPicker.ItemsSource = ListTickets;
                ticketPicker.SelectedIndexChanged += Picker_SelectedIndexChanged;
                ticketPicker.ItemDisplayBinding = new Binding("Id");
                ticketPicker.SelectedIndex = 0;
                string id = ((Ticket)ticketPicker.SelectedItem).Id.ToString();
                var stream = DependencyService.Get<IBarcodeService>().ConvertImageStream(id, 500, 500);
                QRcode.Source = ImageSource.FromStream(() => { return stream; });
            }
            catch
            {
                DependencyService.Get<IMessage>().ShortAlert("No assigned to this mail tickets found. Try again");
                Navigation.PopToRootAsync();
            }
        }

        void OnSwiped(object sender, SwipedEventArgs e)
        {
            switch (e.Direction)
            {
                case SwipeDirection.Left:
                    if (ticketPicker.SelectedIndex < ListTickets.Count)
                        ticketPicker.SelectedIndex++;
                    break;
                case SwipeDirection.Right:
                    if (ticketPicker.SelectedIndex > 0)
                        ticketPicker.SelectedIndex--;
                    break;
            }

            string id = ((Ticket)ticketPicker.SelectedItem).Id.ToString();
            var stream = DependencyService.Get<IBarcodeService>().ConvertImageStream(id, 500, 500);
            QRcode.Source = ImageSource.FromStream(() => { return stream; });
        }

        private async void GetTickets()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "tickets/?Email=" + userEmail;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    ListTickets = JsonConvert.DeserializeObject<List<Ticket>>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                   
                }
            }
            SetPicker();
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "filmshows/?id=" + ((Ticket)(sender as Picker).SelectedItem).FilmShowId + "&filmshow=filmshow";
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    selectedTicketFilmShow = JsonConvert.DeserializeObject<FilmShow>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                }
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "films/" + selectedTicketFilmShow.FilmId;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    selectedTicketFilm = JsonConvert.DeserializeObject<Film>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                }
            }
            TitleValue.Text = selectedTicketFilm.Title;
            TimeValue.Text = selectedTicketFilmShow.Time;
            RoomValue.Text = selectedTicketFilmShow.RoomName;
            SeatValue.Text = ((Ticket)(sender as Picker).SelectedItem).SeatNumber.ToString();
            TypeValue.Text = ((Ticket)(sender as Picker).SelectedItem).Type;
        }
    }
}