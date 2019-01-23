using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketView : ContentPage
    {
        int FilmShowId;
        List<Ticket> ListTicket = new List<Ticket>();
        List<Ticket> ListSelectedTickets = new List<Ticket>();
        Film filmSelected;
        FilmShow filmShow;
        IpConfig ipConfig = new IpConfig();
        Room filmShowRoom;
        public TicketView(Film selectedFilm, FilmShow selectedFilmShow, int selectedFilmShowId)
        {
            InitializeComponent();

            TicketViewTitle.Text = "Title: " + selectedFilm.Title;
            TicketViewDescription.Text = "Description: " + selectedFilm.Description;
            TicketViewDuration.Text = "Duration: " + Environment.NewLine + selectedFilm.Duration.ToString();
            TicketViewRoomAndTime.Text = selectedFilmShow.Time + Environment.NewLine + Environment.NewLine + selectedFilmShow.RoomName;
            filmShow = selectedFilmShow;
            FilmShowId = selectedFilmShowId;
            filmSelected = selectedFilm;
        }

        protected override void OnAppearing()
        {
            ListSelectedTickets.RemoveAll(item => item.IsFree == false);
            LoadRoom();

        }
        private async void LoadTickets()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                    string responseString = "tickets/" + FilmShowId;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    ListTicket = JsonConvert.DeserializeObject<List<Ticket>>(result);
                    int a = 0;
                    int i = 0;

                    foreach (Ticket ticket in ListTicket)
                    {
                        Button button = new Button
                        {
                            Margin = new Thickness(0.5, 0.5, 0.5, 0.5),
                            Text = ticket.SeatNumber.ToString(),
                            HeightRequest = 25,
                            FontSize = 12,
                            Padding = 1,
                            BackgroundColor = Color.LightGray,
                            TabIndex = ticket.Id,
                        };
                        button.Clicked += new EventHandler(Button_Clicked);
                        Grid.SetColumn(button, i % filmShowRoom.NumberOfColumns);
                        if (i % filmShowRoom.NumberOfColumns == 0)
                            a++;
                        Grid.SetRow(button, a);
                        CinemaRoomView.Children.Add(button);
                        i++;
                        if (ticket.IsFree == false && ticket.IsBought == true)
                        {
                            button.BackgroundColor = Color.FromHex("FA4141");
                            button.IsEnabled = false;
                        }
                        if (ticket.IsFree == false && ticket.IsBought == false)
                        {
                            button.BackgroundColor = Color.FromHex("F7F72A");
                            button.IsEnabled = false;
                        }
                    }
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    await Navigation.PopToRootAsync();
                }
            }
        }

        private async void LoadRoom()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                try
                {
                    string responseString = "rooms/" + filmShow.RoomId;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var resultRoom = await response.Content.ReadAsStringAsync();
                    filmShowRoom = JsonConvert.DeserializeObject<Room>(resultRoom);
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");

                }
            }
            LoadTickets();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).BackgroundColor == Color.LightGray)
            {
                (sender as Button).BackgroundColor = Color.GreenYellow;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");

                        Ticket ticket = new Ticket();
                        ticket = ListTicket[Int32.Parse((sender as Button).Text) - 1];
                        if (ticket.IsFree == true)
                        {
                            ticket.IsFree = false;
                            string responseString = "tickets/" + (sender as Button).TabIndex;
                            var json = JsonConvert.SerializeObject(ticket);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            ListSelectedTickets.Add(ticket);
                            HttpResponseMessage response = await client.PutAsync(responseString, content);
                        }
                        else
                        {
                            DependencyService.Get<IMessage>().ShortAlert("Selected ticket is sold");
                        }
                    }
                    catch
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                        await Navigation.PopToRootAsync();
                    }
                }
            }
            else if ((sender as Button).BackgroundColor == Color.GreenYellow)
            {
                (sender as Button).BackgroundColor = Color.LightGray;
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");

                        int x = (sender as Button).TabIndex;
                        Ticket ticket = new Ticket();
                        ticket = ListTicket[Int32.Parse((sender as Button).Text) - 1];
                        ticket.IsFree = true;
                        string responseString = "tickets/" + (sender as Button).TabIndex;
                        var json = JsonConvert.SerializeObject(ticket);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");
                        ListSelectedTickets.Remove(ticket);
                        HttpResponseMessage response = await client.PutAsync(responseString, content);
                    }
                    catch
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                        await Navigation.PopToRootAsync();
                    }
                }
            }
        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuyData(ListSelectedTickets, FilmShowId));
        }
    }
}