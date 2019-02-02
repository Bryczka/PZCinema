using ClientCinemaApp.Services;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace ClientCinemaApp
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeLog : ContentPage
    {
        string ticketId;
        public EmployeeLog()
        {
            InitializeComponent();
        }

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {
            bool authorized = false;
            authorized = await ApiConnector.LogEmployeeService(IdEntry.Text, PasswordEntry.Text);
          
            if (authorized)
            {                
                var scan = new ZXingScannerPage();
                await Navigation.PushAsync(scan);
                scan.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Navigation.PopAsync();
                        DependencyService.Get<IMessage>().ShortAlert(result.Text);
                        ticketId = result.Text;
                        if(ticketId!="")
                        PushTicketToDelete();
                    });
                };   
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Wrong password. Try again!");
            }
        }

        private void PushTicketToDelete()
        {
            Navigation.PushAsync(new TicketToDeleteView(ticketId));
        }
    }
}