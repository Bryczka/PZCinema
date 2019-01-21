using ClientCinemaApp.Database_classes;
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
        public BuyData(List<Ticket> SelectedTickets)
        {
            InitializeComponent();
            ListSelectedTickets = SelectedTickets;
            Buying = true;
        }

        public BuyData()
        {
            InitializeComponent();
            Buying = false;
        }

        private void ConfirmButton_Clicked(object sender, EventArgs e)
        {

            string email = EmailEntry.Text;
            if (Buying == true)
            {
                Navigation.PushAsync(new BuyTicketView(ListSelectedTickets, email));
            }
            else
            {
                Navigation.PushAsync(new AllTicketsPage(email));
            }
        }
    }
}