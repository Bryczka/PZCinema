using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public CinemaContext context = new CinemaContext();
        public MainWindow()
        {
            InitializeComponent();
  
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmViewSource")));
            context.Films.Include(c => c.FilmShows).Load();
            filmViewSource.Source = context.Films.Local;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            context.Dispose();
        }

        private void AddFilm_Button(object sender, RoutedEventArgs e)
        {
            AddFilm addFilm = new AddFilm();
            addFilm.ShowDialog();

            System.Windows.Data.CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmViewSource")));
            context.Films.Include(c => c.FilmShows).Load();
            filmViewSource.Source = context.Films.Local;
        }

        private void DeleteFilm_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new CinemaContext();
                Film SelectedFilm = (Film)filmDataGrid.SelectedItem;
                int id = SelectedFilm.Id;
                UnitOfWork unitOfWork = new UnitOfWork(context);
                Film SelectedFilmObj = unitOfWork.Film.Get(id);

                var result = MessageBox.Show("Are you sure to delete film?", "Delete" + SelectedFilm.Title, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    unitOfWork.Film.Remove(SelectedFilmObj);
                    unitOfWork.Complete();

                    MessageBox.Show("Deleted film: " + SelectedFilmObj.Title, "Deleted", MessageBoxButton.OK);

                    System.Windows.Data.CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmViewSource")));
                    context.Films.Include(c => c.FilmShows).Load();
                    filmViewSource.Source = context.Films.Local;
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operation stopped!", "Aborted", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                
                    MessageBox.Show("Fail to delete film! Try select film again", "Error", MessageBoxButton.OK);

            }
            
            
        }

        private void AddFilm_Closed()
        {
            
            System.Windows.Data.CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("filmViewSource")));
            context.Films.Include(c => c.FilmShows).Load();
            filmViewSource.Source = context.Films.Local;
        }
    }
}
