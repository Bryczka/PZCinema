using Newtonsoft.Json;
using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketToDeleteView : ContentPage
    {
        FilmShow selectedTicketFilmShow = new FilmShow();
        Film selectedTicketFilm = new Film();
        Ticket ticket = new Ticket();
        string ticketId;
        IpConfig ipConfig = new IpConfig();

        public TicketToDeleteView(string id)
        {
            InitializeComponent();
            ticketId = id;
            GetTickets();

        }



        private async void GetTickets()
        {
            var stream = DependencyService.Get<IBarcodeService>().ConvertImageStream(ticketId, 500, 500);
            QRcode.Source = ImageSource.FromStream(() => { return stream; });

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "tickets/?id=" + ticketId + "&tick=ticket";
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    ticket = JsonConvert.DeserializeObject<Ticket>(result);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                }

            }
            GetFilm();
        }
        private async void GetFilm()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "filmshows/?id=" + ticket.FilmShowId + "&filmshow=filmshow";
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
            SeatValue.Text = ticket.SeatNumber.ToString();
            TypeValue.Text = ticket.Type;


        }



        private async void DeleteTicket_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Do you want to delete?", "Confirm deleting ot this ticket", "Yes", "No");
            if (answer)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                    try
                    {
                        string responseString = "tickets/" + ticketId;
                        HttpResponseMessage response = await client.DeleteAsync(responseString);
                    }
                    catch
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Logging error...");
                    }
                }
                await Navigation.PopAsync();
            }
            DependencyService.Get<IMessage>().ShortAlert("Deleting aborted");

        }
    }
}