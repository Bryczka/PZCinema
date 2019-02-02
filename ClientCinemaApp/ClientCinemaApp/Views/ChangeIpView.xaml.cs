using ClientCinemaApp.Services;
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
        private async void SaveIp_Clicked(object sender, EventArgs e)
        {
            ipConfig.SetIp(IpTextBox.Text);

            if(await ApiConnector.CheckConnection() != null)
            {
                await Navigation.PopToRootAsync();
            }
        }
    }
}