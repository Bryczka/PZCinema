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
    public partial class BuyTicketView : ContentPage
    {
        List<Ticket> ListSelectedTickets = new List<Ticket>();
        List<string> TabOfSelectedTickets = new List<string>();
        List<string> ListOfTypeTickets = new List<string>()
        {
            "Full, Price: 10,00$", "Student, Price: 5,00$", "Child, Price: 6,00$"
        };

        Film selectedFilm;
        string selectedFilmShowData;
        public BuyTicketView(List<Ticket> SelectedTickets, Film film, string selectedFilmShow)
        {
            InitializeComponent();
            ListSelectedTickets = SelectedTickets;
            selectedFilmShowData = selectedFilmShow;
            selectedFilm = film;
            BuyTickets();
            
        }

        public void BuyTickets()
        {
            int i = 0;
            foreach (Ticket ticket in ListSelectedTickets)
            {

                Label label = new Label()
                {
                    Text = "Choose type of ticket number",

                };
                label.FontSize = 25;
                label.TextColor = Color.White;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.HorizontalTextAlignment = TextAlignment.Center;
                BuyTicketMenuView.Children.Add(label);

                Label label1 = new Label()
                {
                    Text = "Seat number: " + ticket.SeatNumber,

                };
                label1.FontSize = 20;
                label1.TextColor = Color.White;
                label1.VerticalTextAlignment = TextAlignment.Center;
                label1.HorizontalTextAlignment = TextAlignment.Center;
                BuyTicketMenuView.Children.Add(label1);

                Label label2 = new Label()
                {
                    Text = "Type of ticket: ",

                };
                label2.FontSize = 20;
                label2.TextColor = Color.White;
                label2.VerticalTextAlignment = TextAlignment.Center;
                label2.HorizontalTextAlignment = TextAlignment.Center;
                BuyTicketMenuView.Children.Add(label2);

                Picker picker = new Picker()
                {
                    TextColor = Color.White

                };
                picker.FontSize = 20;
                picker.ItemsSource = ListOfTypeTickets;
                picker.SelectedItem = ListOfTypeTickets[0];
                BuyTicketMenuView.Children.Add(picker);
                picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
                picker.TabIndex = i;
                TabOfSelectedTickets.Add(picker.SelectedItem.ToString());
                i++;
            }

            Button button = new Button()
            {
                Text = "Buy tickets"
            };
            button.Padding = 1;
            button.BackgroundColor = Color.LightGray;
            BuyTicketMenuView.Children.Add(button);
            button.Clicked += new EventHandler(Button_Clicked);

        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabOfSelectedTickets.Insert(((sender as Picker).TabIndex), (sender as Picker).SelectedItem.ToString());
        }

        private void AfterBuyPage()
        {
            Navigation.PushAsync(new AfterBuyTicketView(ListSelectedTickets, selectedFilm, selectedFilmShowData));
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Ticket ticket in ListSelectedTickets)
            {

                var client = new HttpClient
                {
                    BaseAddress = new Uri("http://192.168.0.102:9095/api/")
                };

                if (TabOfSelectedTickets[i].Equals("Full, Price: 10,00$"))
                {
                    ticket.Price = 10.00;
                    ticket.Type = "Full";

                }
                else if (TabOfSelectedTickets[i].Equals("Student, Price: 5,00$"))
                {
                    ticket.Price = 5.00;
                    ticket.Type = "Student";

                }
                else if (TabOfSelectedTickets[i].Equals("Child, Price: 6,00$"))
                {
                    ticket.Price = 6.00;
                    ticket.Type = "Child";
                };

                string responseString = "tickets/" + ticket.Id;
                var json = JsonConvert.SerializeObject(ticket);
                var content = new StringContent(json, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PutAsync(responseString, content);

                i++;

                
            }
            AfterBuyPage();
        }
    }
}