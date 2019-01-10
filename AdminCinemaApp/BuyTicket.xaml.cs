using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Collections.Generic;
using System.Windows;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : Window
    {
        Ticket selectedTicket;
        public BuyTicket(Ticket ticket)
        {
            InitializeComponent();

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            selectedTicket = ticket;

            List<string> type = new List<string>
            {
                "Full",
                "Student",
                "Child"
            };

            TypeOfTicket.ItemsSource = type;
            TypeOfTicket.Text = type[1];

            Title.Text = ticket.FilmShow.Film.Title;
            NameOfRoom.Text = ticket.FilmShow.RoomName;
            TimeOfFilmShow.Text = ticket.FilmShow.Time;
            SeatNumber.Text = ticket.SeatNumber.ToString();

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            double price = 0;
            if (TypeOfTicket.Text == "Full")
            {
                price = 15.00;
            }
            else if (TypeOfTicket.Text == "Student")
            {
                price = 8.00;
            }
            else if (TypeOfTicket.Text == "Child")
            {
                price = 5.00;
            }

            unitOfWork.Ticket.Get(selectedTicket.Id).IsFree = false;
            unitOfWork.Ticket.Get(selectedTicket.Id).Type = TypeOfTicket.Text;
            unitOfWork.Ticket.Get(selectedTicket.Id).Price = price;

            unitOfWork.Complete();
            this.Close();
        }

    }

}
