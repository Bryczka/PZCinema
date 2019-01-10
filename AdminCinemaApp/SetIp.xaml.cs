using System;
using System.Net;
using System.Windows;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy SetIp.xaml
    /// </summary>
    public partial class SetIp : Window
    {
        IpConfig ipConfig = new IpConfig();
        public SetIp()
        {
            InitializeComponent();
            IpTetBox.Text = ipConfig.GetIp();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if(IPAddress.TryParse(IpTetBox.Text, out IPAddress result))
            {
                ipConfig.SetIp(IpTetBox.Text);
                this.Close();
            }
            else
            {
                this.Close();
            }

        }
    }
}
