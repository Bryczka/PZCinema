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
        List<Price> TabOfSelectedTickets = new List<Price>();
        List<Price> ListOfTypeTickets = new List<Price>();
        string buyerEmail;
        IpConfig ipConfig = new IpConfig();
        int selectedFilmShowId;
        public BuyTicketView(List<Ticket> SelectedTickets, string email, int FilmShowId)
        {
            InitializeComponent();
            ListSelectedTickets = SelectedTickets;
            buyerEmail = email;
            selectedFilmShowId = FilmShowId;
            LoadTypeOfTicketAsync();
        }

        private async void LoadTypeOfTicketAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");

                    string responseString = "prices";
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    ListOfTypeTickets = JsonConvert.DeserializeObject<List<Price>>(result.ToString());
                    BuyTickets();
                }
                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    await Navigation.PopToRootAsync();
                }
            }
        }
        private void BuyTickets()
        {
            int i = 0;
            foreach (Ticket ticket in ListSelectedTickets)
            {
                Label[] labels = new Label[3];

                labels[0] = new Label
                {
                    Text = "Choose type of ticket number"
                };
                labels[1] = new Label
                {
                    Text = "Seat number: " + ticket.SeatNumber
                };
                labels[2] = new Label
                {
                    Text = "Type of ticket: "
                };

                foreach (Label label in labels)
                {
                    label.FontSize = 25;
                    label.TextColor = Color.White;
                    label.VerticalTextAlignment = TextAlignment.Center;
                    label.HorizontalTextAlignment = TextAlignment.Center;
                    BuyTicketMenuView.Children.Add(label);
                }

                Picker picker = new Picker()
                {
                    TextColor = Color.White,
                    FontSize = 20,
                    ItemsSource = ListOfTypeTickets,
                    ItemDisplayBinding = new Binding("TypeOfTicket"),
                    SelectedIndex = 0,
                    TabIndex = i
                };
                TabOfSelectedTickets.Add((Price)picker.SelectedItem);
                picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
                BuyTicketMenuView.Children.Add(picker);
                i++;
            }

            Button button = new Button()
            {
                Text = "Buy tickets"
            };
            button.Padding = 1;
            button.BackgroundColor = Color.WhiteSmoke;
            BuyTicketMenuView.Children.Add(button);
            button.Clicked += new EventHandler(Button_Clicked);
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabOfSelectedTickets[(sender as Picker).TabIndex] = (Price)(sender as Picker).SelectedItem;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Ticket ticket in ListSelectedTickets)
            {



                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                        Ticket ticketCheck = new Ticket();
                        string checkresponseString = "tickets/?id=" + ticket.Id + "&tick=ticket";
                        HttpResponseMessage responseCheck = await client.GetAsync(checkresponseString);
                        var result = await responseCheck.Content.ReadAsStringAsync();
                        ticketCheck = JsonConvert.DeserializeObject<Ticket>(result);

                        if (ticketCheck.UserEmail != null)
                        {
                            DependencyService.Get<IMessage>().ShortAlert("Fail to buy tickets - they are sold");
                            break;
                        }
                        else
                        {
                            var a = TabOfSelectedTickets[i].ToString();
                            ticket.Price = TabOfSelectedTickets[i].Cost;
                            ticket.Type = TabOfSelectedTickets[i].TypeOfTicket;
                            ticket.UserEmail = buyerEmail;
                            ticket.IsBought = true;
                            string responseString = "tickets/" + ticket.Id;
                            var json = JsonConvert.SerializeObject(ticket);
                            var content = new StringContent(json, Encoding.UTF8, "application/json");
                            HttpResponseMessage response = await client.PutAsync(responseString, content);
                            i++;
                        }
                    }
                    catch
                    {
                        DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                        await Navigation.PopToRootAsync();
                    }
                }
            }
            await Navigation.PopToRootAsync();
        }
    }
}