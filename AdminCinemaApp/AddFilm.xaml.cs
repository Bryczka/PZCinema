using CinemaDatabase;
using CinemaDatabase.Persistence;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;

namespace AdminCinemaApp
{
    public partial class AddFilm : Window
    {
        BitmapImage image = new BitmapImage();
        List<string> AgeCategory = new List<string>
            {"0", "7", "12", "15", "18"};
        public AddFilm()
        {
            InitializeComponent();
            Age_limit.ItemsSource = AgeCategory;
        }

        public byte[] ImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
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
                    Description = Description.Text,
                    FilmPoster = ImageToByteArray(image)

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

        private void Browse_Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png,*.jfif)|*.BMP;*.JPG;*.JPEG;*.PNG;*.JFIF"
            };
            if (of.ShowDialog() == true)
            {
                image = new BitmapImage(new Uri(of.FileName, UriKind.Absolute));
                FilmPosterImage.Source = image;
            }
        }
    }
}

