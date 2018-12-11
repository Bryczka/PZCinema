using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.Entity;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddFilm.xaml
    /// </summary>
    public partial class AddFilm : Window
    {
        public AddFilm()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();

            var film = new Film
            {
                Title = Title.Text,
                Age_Limit =  Convert.ToInt32(Age_limit.Text),
                Duration = Convert.ToInt32(Duration.Text),
                Description = Description.Text
            };

            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.Film.Add(film);
            unitOfWork.Complete();
            this.Close();

        }

        
    }
}
