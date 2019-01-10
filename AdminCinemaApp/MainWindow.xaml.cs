using AdminCinemaApp.WebApi;
using CinemaDatabase;
using CinemaDatabase.Persistence;
using Microsoft.Owin.Hosting;
using System;
using System.Data.Entity;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Windows;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static bool test = true;
        public CinemaContext context = new CinemaContext();
        StringBuilder consoleStringBuilder = new StringBuilder();
        Thread thread;

        public MainWindow()
        {

            InitializeComponent();


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Loading_Data();
            thread = new Thread(StartLocalHost);
            thread.Start();
            // Załaduj dane poprzez ustawienie właściwości CollectionViewSource.Source:
            // ticketViewSource.Źródło = [ogólne źródło danych]
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            context.Dispose();
            thread.Abort();
        }

        private void AddFilmShow_Button(object sender, RoutedEventArgs e)
        {

            AddFilmShow addFilmShow = new AddFilmShow();
            addFilmShow.ShowDialog();
            Loading_Data();


        }

        private void DeleteFilmShow_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new CinemaContext();
                FilmShow SelectedFilmShow = (FilmShow)filmShowDataGrid.SelectedItem;
                int id = SelectedFilmShow.Id;
                UnitOfWork unitOfWork = new UnitOfWork(context);
                FilmShow SelectedFilmShowObj = unitOfWork.FilmShow.Get(id);

                var result = MessageBox.Show("Are you sure to delete film show?", "Delete" + SelectedFilmShow.Time, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {

                    foreach (Ticket ticket in SelectedFilmShow.Tickets)
                    {
                        unitOfWork.Ticket.Remove(unitOfWork.Ticket.Get(ticket.Id));
                        unitOfWork.Complete();
                    }


                    unitOfWork.FilmShow.Remove(SelectedFilmShowObj);
                    unitOfWork.Complete();

                    MessageBox.Show("Film show deleted", "Deleted", MessageBoxButton.OK);

                    Loading_Data();

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

        private void AddFilm_Button(object sender, RoutedEventArgs e)
        {
            AddFilm addFilm = new AddFilm();
            addFilm.ShowDialog();

            Loading_Data();
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

                    Loading_Data();
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operation stopped!", "Aborted", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Fail to delete film! You choose no film or try to delete film with active film shows", "Error", MessageBoxButton.OK);

            }


        }

        private void BuyTicket_Button(object sender, RoutedEventArgs e)
        {
            try
            {
                BuyTicket buyTicket = new BuyTicket((Ticket)ticketsDataGrid.SelectedItem);
                buyTicket.ShowDialog();

            }
            catch (Exception)
            {
                MessageBox.Show("Fail to buy ticket", "Error", MessageBoxButton.OK);
            }
            Loading_Data();
        }

        public void Loading_Data()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            System.Windows.Data.CollectionViewSource filmViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("filmViewSource"));
            context.Films.Load();
            filmViewSource.Source = context.Films.Local;

            System.Windows.Data.CollectionViewSource filmShowViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("filmShowViewSource"));
            context.FilmShows.Load();
            filmShowViewSource.Source = context.FilmShows.Local;

            System.Windows.Data.CollectionViewSource ticketViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("ticketViewSource"));
            context.Tickets.Load();
            ticketViewSource.Source = context.Tickets.Local;
        }


        private void ConsoleWrite(string str)
        {
            DateTime date = DateTime.Now;
            string dateTime = "[" + date.ToString() + "] : ";
            consoleStringBuilder.Insert(0, Environment.NewLine + dateTime + str, 1);
            ConsoleWindow.Text = consoleStringBuilder.ToString();
        }

        private void StartLocalHost()
        {
            IpConfig ipConfig = new IpConfig();
            StartOptions options = new StartOptions();
          
            while (true)
            {
                options.Urls.Clear();
                string ip = "http://" + ipConfig.GetIp()+ ":9095";
                options.Urls.Add(ip);
                
                try
                {
                    using (WebApp.Start<Startup>(options))
                    {
                        Dispatcher.Invoke(new Action(() =>
                        {
                        ConsoleWrite("Web server is running. IP: " + ip);
                            HttpClient client = new HttpClient();

                        }));
                        while (true)
                        {
                            if (test == false)
                            {
                                Dispatcher.Invoke(new Action(() =>
                                {
                                    Loading_Data();

                                }));

                                test = true;
                            }
                        }
                        ;
                    }
                }
                catch
                {
                    Dispatcher.Invoke(new Action(() =>
                    {
                        SetIp setIp = new SetIp();
                        setIp.ShowDialog();

                    }));


                }
            }
        }

    }

}
