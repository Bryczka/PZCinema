using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AfterBuyTicketView : ContentPage
    {
        List<Ticket> ListBoughtTickets = new List<Ticket>();
        Film selectedFilm;
        string selectedFilmShowRoom;
        string selectedFilmShowTime;
        public AfterBuyTicketView(List<Ticket> BoughtTickets, Film film, string selectedFilmShow)
        {
            InitializeComponent();
            ListBoughtTickets = BoughtTickets;
            selectedFilm = film;

            int splitString = selectedFilmShow.IndexOf("Time");
            selectedFilmShowRoom = selectedFilmShow.Substring(0, splitString);
            selectedFilmShowTime = selectedFilmShow.Substring(splitString);

            SaveToFilesTickets();

           
        }

        protected override bool OnBackButtonPressed()
        {

            Navigation.PopToRootAsync();
            // If you want to continue going back
            base.OnBackButtonPressed();
            return false;

            // If you want to stop the back button
            //return true;

        }

        public async void SaveToFilesTickets()
        {


            foreach (Ticket ticket in ListBoughtTickets)
            {

                string[] text = new string[4];
                text[0] = JsonConvert.SerializeObject(ticket);
                text[1] = JsonConvert.SerializeObject(selectedFilm);
                text[2] = selectedFilmShowRoom;
                text[3] = selectedFilmShowTime;


                string filename = "ticket_" + ticket.Id;
                IFolder folder = FileSystem.Current.LocalStorage;
                IFile file = await folder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
                await file.WriteAllTextAsync(text[0] + ";" + text[1] + ";" + text[2] + ";" + text[3]);


                Label label = new Label()
                {
                    Text = selectedFilm.Title,

                };
                label.FontSize = 25;
                label.TextColor = Color.White;
                label.VerticalTextAlignment = TextAlignment.Center;
                label.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label);

                Label label1 = new Label()
                {
                    Text = selectedFilmShowRoom,

                };
                label1.FontSize = 25;
                label1.TextColor = Color.White;
                label1.VerticalTextAlignment = TextAlignment.Center;
                label1.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label1);

                Label label2 = new Label()
                {
                    Text = selectedFilmShowTime,


                };
                label2.FontSize = 25;
                label2.TextColor = Color.White;
                label2.VerticalTextAlignment = TextAlignment.Center;
                label2.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label2);


                Label label3 = new Label()
                {
                    Text = "Seat number: " + ticket.SeatNumber.ToString(),

                };
                label3.FontSize = 25;
                label3.TextColor = Color.White;
                label3.VerticalTextAlignment = TextAlignment.Center;
                label3.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label3);


                Label label4 = new Label()
                {
                    Text = "Pirce of ticket: " + ticket.Price.ToString() + "$",

                };
                label4.FontSize = 25;
                label4.TextColor = Color.White;
                label4.VerticalTextAlignment = TextAlignment.Center;
                label4.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label4);

                Label label5 = new Label()
                {
                    Text = "Ticket ID: " + ticket.Id.ToString(),

                };
                label5.FontSize = 25;
                label5.TextColor = Color.White;
                label5.VerticalTextAlignment = TextAlignment.Center;
                label5.HorizontalTextAlignment = TextAlignment.Center;
                AfterBuyTicketViewLayout.Children.Add(label5);

                Label label6 = new Label()
                {

                };
                label6.BackgroundColor = Color.White;
                label6.HeightRequest = 2;
                label6.WidthRequest = Application.Current.MainPage.Width;
                AfterBuyTicketViewLayout.Children.Add(label6);

            }
        }


    }
}