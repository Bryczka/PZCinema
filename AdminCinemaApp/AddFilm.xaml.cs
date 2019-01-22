using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Windows;

namespace AdminCinemaApp
{
    public partial class AddFilm : Window
    {
        List<string> AgeCategory = new List<string>
            {"N/A", "7", "12", "15", "18"};
        public AddFilm()
        {
            InitializeComponent();
            Age_limit.ItemsSource = AgeCategory;
        }

        public void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            try
            {
                var film = new Film
                {
                    Title = Title.Text,
                    Age_Limit = Int32.Parse(Age_limit.SelectionBoxItem.ToString()),
                    Duration = Convert.ToInt32(Duration.Text),
                    Description = Description.Text
                };

                UnitOfWork unitOfWork = new UnitOfWork(context);
                unitOfWork.Film.Add(film);
                unitOfWork.Complete();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Invalid data! Try again", "Error", MessageBoxButton.OK);
            }
        }
    }


}

