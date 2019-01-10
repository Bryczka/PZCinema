using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTicketsView : ContentPage
    {
        public MyTicketsView()
        {
            InitializeComponent();
            ShowList();
        }

        public async void ShowList()
        {

            IFolder folder = FileSystem.Current.LocalStorage;
            IList<IFile> TicketFiles = await folder.GetFilesAsync();


            foreach (IFile Ticketfile in TicketFiles)
            {
                string[] textReaded = new string[4];
                textReaded = (await Ticketfile.ReadAllTextAsync()).Split(';');
                Ticket ticket = JsonConvert.DeserializeObject<Ticket>(textReaded[0]);
                Film film = JsonConvert.DeserializeObject<Film>(textReaded[1]);
                string selectedFilmShowRoom = textReaded[2];
                string selectedFilmShowTime = textReaded[3];


                Label label = new Label()
                {
                    Text = film.Title,

                };
                label.FontSize = 25;
                label.TextColor = Color.White;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label);

                Label label1 = new Label()
                {
                    Text = selectedFilmShowRoom,

                };
                label1.FontSize = 25;
                label1.TextColor = Color.White;
                label1.VerticalTextAlignment = TextAlignment.Center;
                label1.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label1);

                Label label2 = new Label()
                {
                    Text = selectedFilmShowTime,


                };
                label2.FontSize = 25;
                label2.TextColor = Color.White;
                label2.VerticalTextAlignment = TextAlignment.Center;
                label2.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label2);


                Label label3 = new Label()
                {
                    Text = "Seat number: " + ticket.SeatNumber.ToString(),

                };
                label3.FontSize = 25;
                label3.TextColor = Color.White;
                label3.VerticalTextAlignment = TextAlignment.Center;
                label3.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label3);


                Label label4 = new Label()
                {
                    Text = "Pirce of ticket: " + ticket.Price.ToString() + "$",

                };
                label4.FontSize = 25;
                label4.TextColor = Color.White;
                label4.VerticalTextAlignment = TextAlignment.Center;
                label4.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label4);

                Label label5 = new Label()
                {
                    Text = "Ticket ID: " + ticket.Id.ToString(),

                };
                label5.FontSize = 25;
                label5.TextColor = Color.White;
                label5.VerticalTextAlignment = TextAlignment.Center;
                label5.HorizontalTextAlignment = TextAlignment.Center;
                MyTickets.Children.Add(label5);

                Label label6 = new Label()
                {


                };
                label6.BackgroundColor = Color.White;
                label6.HeightRequest = 2;
                label6.WidthRequest = Application.Current.MainPage.Width;
                MyTickets.Children.Add(label6);

            }

        }
    }
}