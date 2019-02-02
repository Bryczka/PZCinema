using ClientCinemaApp.Services;
using System;
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
            ticket = await ApiConnector.GetTicketService(ticketId);
            GetFilm();
        }
        private async void GetFilm()
        {
            selectedTicketFilmShow = await ApiConnector.GetFilmShowService(ticket.FilmShowId);
            selectedTicketFilm = await ApiConnector.GetFilmService(selectedTicketFilmShow.FilmId);
            try
            {
                TitleValue.Text = selectedTicketFilm.Title;
                TimeValue.Text = selectedTicketFilmShow.Time;
                RoomValue.Text = selectedTicketFilmShow.RoomName;
                SeatValue.Text = ticket.SeatNumber.ToString();
                TypeValue.Text = ticket.Type;
            }
            catch
            {
                DependencyService.Get<IMessage>().ShortAlert("Wrong QR code, scan again");
                await Navigation.PopAsync();
            }
        }

        private async void DeleteTicket_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Do you want to delete?", "Confirm deleting this ticket", "Yes", "No");
            if (answer)
            {
                ApiConnector.DeleteUseTicketService(ticketId);
                await Navigation.PopAsync();
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Deleting aborted");
                await Navigation.PopAsync();
            }
        }

        private async void UseTicket_Clicked(object sender, EventArgs e)
        {
            if (ticket.IsUsed == true)
            {
                await DisplayAlert("Ticket used!", "You cannot use deleted or used ticket!", "OK");
            }
            else
            {
                var answer = await DisplayAlert("Do you want to use ticket?", "Confirm using ot this ticket", "Yes", "No");
                if (answer)
                {
                    ApiConnector.DeleteUseTicketService("?id=" + ticketId + "&tick=ticket");
                    await Navigation.PopAsync();
                }
                else
                {
                    DependencyService.Get<IMessage>().ShortAlert("Using aborted");
                    await Navigation.PopAsync();
                }
            }
        }
    }
}