using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyData : ContentPage
    {
        List<Ticket> ListSelectedTickets = new List<Ticket>();
        bool Buying = false;
        int selectedFilmShowId;
        public BuyData(List<Ticket> SelectedTickets, int FilmShowId)
        {
            InitializeComponent();
            ListSelectedTickets = SelectedTickets;
            Buying = true;
            selectedFilmShowId = FilmShowId;
        }

        public BuyData()
        {
            InitializeComponent();
            Buying = false;
        }

        private void ConfirmButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text.ToLower();
            if (Buying == true)
            {
                if (email == "")
                {
                    DependencyService.Get<IMessage>().ShortAlert("Enter email address!");
                }
                else
                {
                    Navigation.PushAsync(new BuyTicketView(ListSelectedTickets, email, selectedFilmShowId));
                }
            }
            else
            {
                Navigation.PushAsync(new AllTicketsPage(email));
            }
        }
    }
}