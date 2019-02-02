using AdminCinemaApp.WebApi;
using CinemaDatabase;
using CinemaDatabase.Persistence;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using ZXing;

namespace AdminCinemaApp
{
    public partial class MainWindow : Window
    {
        public static bool reload = true;
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
            System.Windows.Data.CollectionViewSource roomViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("roomViewSource")));
            System.Windows.Data.CollectionViewSource priceViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("priceViewSource")));
            System.Windows.Data.CollectionViewSource usereViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("userViewSource")));
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
            var tickets = context.Tickets.Local;
            ticketViewSource.Source = tickets.Where(t => t.IsFree == false);

            System.Windows.Data.CollectionViewSource roomViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("roomViewSource"));
            context.Rooms.Load();
            roomViewSource.Source = context.Rooms.Local;

            System.Windows.Data.CollectionViewSource priceViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("priceViewSource"));
            context.Prices.Load();
            priceViewSource.Source = context.Prices.Local;

            System.Windows.Data.CollectionViewSource userViewSource = ((System.Windows.Data.CollectionViewSource)FindResource("userViewSource"));
            context.Employees.Load();
            userViewSource.Source = context.Employees.Local;
        }


        private void StartLocalHost()
        {
            IpConfig ipConfig = new IpConfig();
            StartOptions options = new StartOptions();

            while (true)
            {
                options.Urls.Clear();
                string ip = "http://" + ipConfig.GetIp() + ":9095";
                options.Urls.Add(ip);

                try
                {
                    using (WebApp.Start<Startup>(options))
                    {
                        HttpClient client = new HttpClient();

                        while (true)
                        {
                            if (reload == false)
                            {
                                CheckTickets();
                                Dispatcher.Invoke(new Action(() =>
                                {
                                    Loading_Data();
                                }));
                                reload = true;
                            }
                        };
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

        private void CheckTickets()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            List<Ticket> AllTickets = new List<Ticket>();
            AllTickets = (List<Ticket>)unitOfWork.Ticket.GetAll();

            foreach (Ticket ticket in AllTickets)
            {
                if (ticket.BuyTime.Equals(new DateTime(1900, 1, 1, 1, 1, 1)))
                {
                    DateTime dateTimeNow = DateTime.Now;
                    if (dateTimeNow.Subtract(ticket.ChooseTime).TotalMinutes > 15)
                    {
                        unitOfWork.Ticket.Get(ticket.Id).IsFree = true;
                        unitOfWork.Ticket.Get(ticket.Id).ChooseTime = new DateTime(1900, 1, 1, 1, 1, 1);
                        unitOfWork.Complete();
                    }else if (ticket.UserEmail != null)
                    {
                        unitOfWork.Ticket.Get(ticket.Id).IsBought = true;
                        unitOfWork.Complete();
                        Loading_Data();
                    }

                }

            }
        }

        private void AddTicketType_Click(object sender, RoutedEventArgs e)
        {
            AddTicketType addTicketType = new AddTicketType();
            addTicketType.ShowDialog();
            Loading_Data();
        }

        private void DeleteTicketType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new CinemaContext();
                Price SelectedPrice = (Price)priceDataGrid.SelectedItem;
                int id = SelectedPrice.Id;
                UnitOfWork unitOfWork = new UnitOfWork(context);
                Price SelectedPriceObj = unitOfWork.Price.Get(id);
                var result = MessageBox.Show("Are you sure to delete ticket type?", "Delete" + SelectedPrice.TypeOfTicket, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    unitOfWork.Price.Remove(SelectedPriceObj);
                    unitOfWork.Complete();
                    MessageBox.Show("Deleted type of ticket: " + SelectedPriceObj.TypeOfTicket, "Deleted", MessageBoxButton.OK);
                    Loading_Data();
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operation stopped!", "Aborted", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail to delete type of ticket. You choose no ticket. Try again!", "Error", MessageBoxButton.OK);
            }
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            AddRoom addRoom = new AddRoom();
            addRoom.ShowDialog();
            Loading_Data();
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new CinemaContext();
                Room SelectedRoom = (Room)roomDataGrid.SelectedItem;
                int id = SelectedRoom.Id;
                UnitOfWork unitOfWork = new UnitOfWork(context);
                Room SelectedRoomObj = unitOfWork.Room.Get(id);
                var result = MessageBox.Show("Are you sure to delete room?", "Delete" + SelectedRoom.Name, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    unitOfWork.Room.Remove(SelectedRoomObj);
                    unitOfWork.Complete();
                    MessageBox.Show("Deleted room: " + SelectedRoomObj.Name, "Deleted", MessageBoxButton.OK);
                    Loading_Data();
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operation stopped!", "Aborted", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail to delete room. You choose no room. Try again!", "Error", MessageBoxButton.OK);
            }
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployee addEmployee = new AddEmployee();
            addEmployee.ShowDialog();
            Loading_Data();
        }
        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var context = new CinemaContext();
                Employee SelectedEmployee = (Employee)employeeDataGrid.SelectedItem;
                int id = SelectedEmployee.Id;
                UnitOfWork unitOfWork = new UnitOfWork(context);
                Employee SelectedEmployeeObj = unitOfWork.Employee.Get(id);
                var result = MessageBox.Show("Are you sure to delete employee?", "Delete" + SelectedEmployee.Name + SelectedEmployee.Surname, MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    unitOfWork.Employee.Remove(SelectedEmployeeObj);
                    unitOfWork.Complete();
                    MessageBox.Show("Deleted employee: " + SelectedEmployee.Name +" "+ SelectedEmployee.Surname, "Deleted", MessageBoxButton.OK);
                    Loading_Data();
                }
                else if (result == MessageBoxResult.No)
                {
                    MessageBox.Show("Operation stopped!", "Aborted", MessageBoxButton.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Fail to delete employee. You choose no employee. Try again!", "Error", MessageBoxButton.OK);
            }
        }

    }
}