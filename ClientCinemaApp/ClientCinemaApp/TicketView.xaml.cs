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
        string selectedFilmShowData;
        public TicketView(Film selectedFilm, string selectedFilmShow, int selectedFilmShowId)
        {
            InitializeComponent();

            TicketViewTitle.Text = "Title: " + selectedFilm.Title;
            TicketViewDescription.Text = "Description: " + selectedFilm.Description;
            TicketViewDuration.Text = "Duration: " + Environment.NewLine + selectedFilm.Duration.ToString();
            TicketViewRoomAndTime.Text = selectedFilmShow;
            selectedFilmShowData = selectedFilmShow;
            FilmShowId = selectedFilmShowId;
            filmSelected = selectedFilm;
            LoadTickets();

        }

        protected override bool OnBackButtonPressed()
        {

            Application.Current.MainPage.Navigation.PopAsync();
            base.OnBackButtonPressed();
            return false;

        }

        private async void LoadTickets()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.0.102:9095/api/")
            };
            string responseString = "tickets/" + FilmShowId;
            HttpResponseMessage response = await client.GetAsync(responseString);
            var result = await response.Content.ReadAsStringAsync();


            ListTicket = JsonConvert.DeserializeObject<List<Ticket>>(result);

            double a = ListTicket.Count;
            a = (int)Math.Sqrt(a);
            int i = 0;
            foreach (Ticket ticket in ListTicket)
            {
                Button button = new Button
                {
                    Margin = new Thickness(0.5, 0.5, 0.5, 0.5),
                    Text = ticket.SeatNumber.ToString()


                };
                button.HeightRequest = 25;
                button.FontSize = 12;
                button.Padding = 1;
                button.BackgroundColor = Color.LightGray;
                button.Clicked += new EventHandler(Button_Clicked);
                button.TabIndex = ticket.Id;
                Grid.SetColumn(button, i % (int)(a));
                Grid.SetRow(button, i / (int)a);
                CinemaRoomView.Children.Add(button);
                i++;
                
                if (ticket.IsFree == false)
                {
                    button.BackgroundColor = Color.DarkGray;
                    button.IsEnabled = false;
                }
            }

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            if ((sender as Button).BackgroundColor == Color.LightGray)
            {
                (sender as Button).BackgroundColor = Color.GreenYellow;

                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://192.168.0.102:9095/api/")
                };


                int x = (sender as Button).TabIndex;
                Ticket ticket = new Ticket();
                ticket = ListTicket[Int32.Parse((sender as Button).Text) - 1];
                ticket.IsFree = false;
                string responseString = "tickets/" + (sender as Button).TabIndex;
                var json = JsonConvert.SerializeObject(ticket);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                ListSelectedTickets.Add(ticket);

                HttpResponseMessage response = await client.PutAsync(responseString, content);



            }
            else if ((sender as Button).BackgroundColor == Color.GreenYellow)
            {
                (sender as Button).BackgroundColor = Color.LightGray;
                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://192.168.0.102:9095/api/")
                };


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


        }

        private void Save_Button_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new BuyTicketView(ListSelectedTickets, filmSelected, selectedFilmShowData));

        }
    }
}