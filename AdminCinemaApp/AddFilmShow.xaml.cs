using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace AdminCinemaApp
{
    public partial class AddFilmShow : Window
    {
        Room selectedRoom = new Room();
        FilmShow addedFilmShow = new FilmShow();
        public AddFilmShow()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            InitializeComponent();
            ObservableCollection<Film> listOfFilms = new ObservableCollection<Film>();
            ObservableCollection<Room> listOfRooms = new ObservableCollection<Room>();

            foreach (Film film in unitOfWork.Film.GetAll())
            {
                listOfFilms.Add(unitOfWork.Film.Get(film.Id));
                FilmShowTitle.ItemsSource = listOfFilms;
            }

            foreach (Room room in unitOfWork.Room.GetAll())
            {
                listOfRooms.Add(unitOfWork.Room.Get(room.Id));
                RoomName.ItemsSource = listOfRooms;
            }
        }

        private void RoomName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Room selectedRoom = (Room)RoomName.SelectedItem;
            NumberOfSeats.Text = selectedRoom.NumberOfSeats.ToString();
        }
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            Film selectedFilm = (Film)FilmShowTitle.SelectedItem;
            selectedRoom = (Room)RoomName.SelectionBoxItem;

            var filmShow = new FilmShow
            {
                Time = TimeOfFilmShow.Text,
                RoomName = selectedRoom.Name,
                NumberOfSeats = Int32.Parse(NumberOfSeats.Text),
                Film = unitOfWork.Film.Get(selectedFilm.Id),
                FilmId = selectedFilm.Id,
                RoomId = selectedRoom.Id
            };
            addedFilmShow = filmShow;
            unitOfWork.FilmShow.Add(filmShow);
            unitOfWork.Complete();

            for (int i = 1; i < int.Parse(NumberOfSeats.Text) + 1; i++)
            {
                var seat = new Ticket
                {
                    FilmShow = unitOfWork.FilmShow.Get(filmShow.Id),
                    SeatNumber = i,
                    IsFree = true,
                    FilmShowId = addedFilmShow.Id,
                    IsUsed = false,
                    ChooseTime = new DateTime(1900, 1, 1, 1, 1, 1),
                    BuyTime = new DateTime(1900, 1, 1, 1, 1, 1),
                };
                unitOfWork.Ticket.Add(seat);
                unitOfWork.Complete();
            }
            this.Close();
        }
    }
}
