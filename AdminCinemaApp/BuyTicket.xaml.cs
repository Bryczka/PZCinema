using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Collections.ObjectModel;
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
            ObservableCollection<Price> type = new ObservableCollection<Price>();

            InitializeComponent();

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            selectedTicket = ticket;

            foreach (Price price in unitOfWork.Price.GetAll())
            {
                type.Add(unitOfWork.Price.Get(price.Id));
                TypeOfTicket.ItemsSource = type;
            }

            Title.Text = ticket.FilmShow.Film.Title;
            NameOfRoom.Text = ticket.FilmShow.RoomName;
            TimeOfFilmShow.Text = ticket.FilmShow.Time;
            SeatNumber.Text = ticket.SeatNumber.ToString();

        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            Price price = (Price)TypeOfTicket.SelectionBoxItem;
            unitOfWork.Ticket.Get(selectedTicket.Id).IsFree = false;
            unitOfWork.Ticket.Get(selectedTicket.Id).IsBought = true;
            unitOfWork.Ticket.Get(selectedTicket.Id).Type = price.TypeOfTicket;
            unitOfWork.Ticket.Get(selectedTicket.Id).Price = price.Cost;
            unitOfWork.Complete();
            this.Close();
        }

    }

}
