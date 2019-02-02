using ClientCinemaApp.Services;
using System;
using System.Collections.Generic;
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
            ListTickets = await ApiConnector.GetTicketListService("?Email=" + userEmail);
            if (ListTickets == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Fail to download tickets");
                await Navigation.PopToRootAsync();
            }
            else
            {
                SetPicker();
            }
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTicketFilmShow = await ApiConnector.GetFilmShowService(((Ticket)(sender as Picker).SelectedItem).FilmShowId);
            selectedTicketFilm = await ApiConnector.GetFilmService(selectedTicketFilmShow.FilmId);

            if (selectedTicketFilmShow == null | selectedTicketFilm == null)
            {
                DependencyService.Get<IMessage>().ShortAlert("Fail to download tickets");
                await Navigation.PopToRootAsync();
            }
            else
            {
                TitleValue.Text = selectedTicketFilm.Title;
                TimeValue.Text = selectedTicketFilmShow.Time;
                RoomValue.Text = selectedTicketFilmShow.RoomName;
                SeatValue.Text = ((Ticket)(sender as Picker).SelectedItem).SeatNumber.ToString();
                TypeValue.Text = ((Ticket)(sender as Picker).SelectedItem).Type;
            }
        }
    }
}