using System;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace ClientCinemaApp
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeLog : ContentPage
    {
        string ticketId;
        IpConfig ipConfig = new IpConfig();
        public EmployeeLog()
        {
            InitializeComponent();
        }

        private async void LogInButton_Clicked(object sender, EventArgs e)
        {

            bool authorized = false;
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://" + ipConfig.GetIpAsync() + ":9095/api/");
                    string responseString = "employees/?id=" + IdEntry.Text + "&password=" + PasswordEntry.Text;
                    HttpResponseMessage response = await client.GetAsync(responseString);
                    var result = await response.Content.ReadAsStringAsync();
                    authorized = Boolean.Parse(result);

                }

                catch
                {
                    DependencyService.Get<IMessage>().ShortAlert("Connection error...");
                    await Navigation.PopToRootAsync();
                }
            }

            if (authorized)
            {
                
                var scan = new ZXingScannerPage();
                await Navigation.PushAsync(scan);
                scan.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        //await Navigation.PopAsync();
                        DependencyService.Get<IMessage>().ShortAlert(result.Text);
                        ticketId = result.Text;
                        if(ticketId!="")
                        PushTicketToDelete();
                        //await Navigation.PushAsync(new TicketToDeleteView(result.Text));
                    });
                };
                //
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert("Wrong password or id. Try again!");
            }
        }

        private void PushTicketToDelete()
        {
            Navigation.PushAsync(new TicketToDeleteView(ticketId));
        }
    }
}