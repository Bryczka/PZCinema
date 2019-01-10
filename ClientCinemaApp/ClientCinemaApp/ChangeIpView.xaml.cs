using System;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientCinemaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangeIpView : ContentPage
    {
        IpConfig ipConfig = new IpConfig();
       
        public ChangeIpView()
        {
            InitializeComponent();
            IpTextBox.Text = ipConfig.GetIpAsync();
        }
        protected override bool OnBackButtonPressed()
        {

            Application.Current.MainPage.Navigation.PopAsync();
            // If you want to continue going back
            base.OnBackButtonPressed();
            return false;

            // If you want to stop the back button
            //return true;

        }
        private async void SaveIp_Clicked(object sender, EventArgs e)
        {
            ipConfig.SetIp(IpTextBox.Text);
            try
            {
              
                DependencyService.Get<IMessage>().ShortAlert("Checking connection...");

                string ip = "http://" + ipConfig.GetIpAsync() + ":9095/api/";
                var client = new HttpClient
                {
                    BaseAddress = new Uri(ip)
                };
                HttpResponseMessage response = await client.GetAsync("films");
                await Navigation.PopToRootAsync();
            }
            catch
            {
                DependencyService.Get<IMessage>().ShortAlert("Fail to connect. Wrong IP address. Try again!");
            }

        }
    }
}