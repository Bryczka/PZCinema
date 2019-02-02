using ClientCinemaApp.Services;
using System;
using System.Collections.Generic;
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
            ListOfTypeTickets = await ApiConnector.GetPriceListService();
            if (ListOfTypeTickets != null)
            {
                BuyTickets();
            }
            else
            {
                await Navigation.PopToRootAsync();
            }
        }
        private void BuyTickets()
        {
            int i = 0;
            foreach (Ticket ticket in ListSelectedTickets)
            {
                Label[] labels = new Label[2];
                labels[0] = new Label
                {
                    Text = "Seat number: " + ticket.SeatNumber
                };
                labels[1] = new Label
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
                picker.FontSize = 30;
                picker.FontAttributes = FontAttributes.Bold;
                picker.Margin = new Thickness(5, 10, 5, 20);
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
                Ticket ticketCheck = new Ticket();
                ticketCheck = await ApiConnector.GetTicketService(ticket.Id.ToString());
                if (ticketCheck == null)
                {
                    await Navigation.PopToRootAsync();
                }
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

                    if (!await ApiConnector.PutTicketService(ticket))
                    {
                        await Navigation.PopToRootAsync();
                    }
                    i++;
                }
            }
            await Navigation.PopToRootAsync();
        }
    }
}