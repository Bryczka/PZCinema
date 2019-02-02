using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorView : ContentPage
    {
        public AuthorView()
        {
            InitializeComponent();
        }
        private async void LogToScan_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmployeeLog());
        }
    }
}