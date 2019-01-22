using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Windows;

namespace AdminCinemaApp
{
    public partial class AddRoom : Window
    {
        int RowsCount = 0;
        int ColumnsCount = 0;
        public AddRoom()
        {
            InitializeComponent();
        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            try
            {
                var room = new Room
                {
                    Name = Name.Text,
                    NumberOfColumns = Int32.Parse(Columns.Text),
                    NumberOfRows = Int32.Parse(Rows.Text),
                    NumberOfSeats = Int32.Parse(NumberOfSeats.Text)
                };
                UnitOfWork unitOfWork = new UnitOfWork(context);
                unitOfWork.Room.Add(room);
                unitOfWork.Complete();
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid data! Try again", "Error", MessageBoxButton.OK);
            }
        }

        private void AddRow_Click(object sender, RoutedEventArgs e)
        {
            if (RowsCount < 10)
            {
                RowsCount++;
                Rows.Text = RowsCount.ToString();
                NumberOfSeats.Text = (RowsCount * ColumnsCount).ToString();
            }
        }

        private void DelRow_Click(object sender, RoutedEventArgs e)
        {
            if (RowsCount > 0)
            {
                RowsCount--;
                Rows.Text = RowsCount.ToString();
                NumberOfSeats.Text = (RowsCount * ColumnsCount).ToString();
            }
        }

        private void AddColumn_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnsCount < 10)
            {
                ColumnsCount++;
                Columns.Text = ColumnsCount.ToString();
                NumberOfSeats.Text = (RowsCount * ColumnsCount).ToString();
            }
        }
        private void DelColumn_Click(object sender, RoutedEventArgs e)
        {
            if (ColumnsCount > 0)
            {
                ColumnsCount--;
                Columns.Text = ColumnsCount.ToString();
                NumberOfSeats.Text = (RowsCount * ColumnsCount).ToString();
            }
        }
    }
}
