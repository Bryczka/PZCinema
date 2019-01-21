using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.IO;
using System.Security.Cryptography;
using System.Windows;

namespace AdminCinemaApp
{
    /// <summary>
    /// Logika interakcji dla klasy AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        SymmetricAlgorithm sa = new TripleDESCryptoServiceProvider();
        byte[] Key = { 0x21, 0x12, 0x43, 0x34, 0x65, 0x56, 0x87, 0x78, 0x09, 0x19, 0x51, 0x42, 0x33, 0x24, 0x15, 0x06 };
        byte[] IV = { 0x91, 0x82, 0x73, 0x64, 0x55, 0x46, 0x37, 0x28, 0x19, 0x19, 0x91, 0x65, 0x33, 0x24, 0x43, 0x24 };
        public AddEmployee()
        {
            InitializeComponent();
        }

        private byte[] Encrypt(SymmetricAlgorithm symmetricAlgorithm, string text)
        {
            ICryptoTransform encryptor = symmetricAlgorithm.CreateEncryptor(Key, IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(text);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

    /*    private string Decrypt(SymmetricAlgorithm symmetricAlgorithm, byte[] msg)
        {
            ICryptoTransform decryptor = symmetricAlgorithm.CreateDecryptor(symmetricAlgorithm.Key, symmetricAlgorithm.IV);
            using (var msDecrypt = new MemoryStream(msg))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }*/

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();

            if (PasswordOfEmployee.Text == ConfirmPasswordOfEmployee.Text)
            {
                try
                {
                    Employee employee = new Employee
                    {
                        Name = NameOfEmployee.Text,
                        Surname = SurnameOfEmployee.Text,
                        Password = Encrypt(sa, PasswordOfEmployee.Text),
                        Email = EmailOfEmployee.Text,

                    };

                    UnitOfWork unitOfWork = new UnitOfWork(context);
                    unitOfWork.Employee.Add(employee);
                    unitOfWork.Complete();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Invalid data! Try again", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                MessageBox.Show("Check password, it must be the same one...", "Error", MessageBoxButton.OK);
            }
        }
    }
}
