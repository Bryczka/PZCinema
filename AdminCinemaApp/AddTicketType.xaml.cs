using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Windows;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddTicketType.xaml
    /// </summary>
    public partial class AddTicketType : Window
    {
        public AddTicketType()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            try
            {
                var price = new Price
                {
                    TypeOfTicket = TypeOfTicket.Text,
                    Cost = Double.Parse(PriceOfTicket.Text)
                };

                UnitOfWork unitOfWork = new UnitOfWork(context);
                unitOfWork.Price.Add(price);
                unitOfWork.Complete();
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid data! Try again", "Error", MessageBoxButton.OK);
            }
        }
    }
}
