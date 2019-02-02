using ClientCinemaApp.Services;
using System;
using System.Collections.Generic;
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
            if (ListTicket != null)
            {
                ListTicket = await ApiConnector.GetTicketListService(FilmShowId.ToString());
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
            else
            {
                await Navigation.PopToRootAsync();
            }
        }

        private async void LoadRoom()
        {
            filmShowRoom = await ApiConnector.GetRoomService(filmShow.RoomId);
            LoadTickets();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).BackgroundColor == Color.LightGray)
            {
                (sender as Button).BackgroundColor = Color.GreenYellow;
                Ticket ticket = new Ticket();
                ticket = ListTicket[Int32.Parse((sender as Button).Text) - 1];

                if (ticket.IsFree == true)
                {
                    ticket.IsFree = false;
                    await ApiConnector.PutTicketService((sender as Button).TabIndex, ticket);
                    ListSelectedTickets.Add(ticket);
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("Selected ticket is sold");
                    await Navigation.PopToRootAsync();
                }
            }
            else if ((sender as Button).BackgroundColor == Color.GreenYellow)
            {
                (sender as Button).BackgroundColor = Color.LightGray;
                int x = (sender as Button).TabIndex;
                Ticket ticket = new Ticket();
                ticket = ListTicket[Int32.Parse((sender as Button).Text) - 1];
                ticket.IsFree = true;
                if (await ApiConnector.PutTicketService((sender as Button).TabIndex, ticket))
                {
                    ListSelectedTickets.Remove(ticket);
                }
                else
                {
                    await Navigation.PopToRootAsync();
                }
            }
        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BuyData(ListSelectedTickets, FilmShowId));
        }
    }
}