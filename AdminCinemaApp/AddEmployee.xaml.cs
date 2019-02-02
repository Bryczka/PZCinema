using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace AdminCinemaApp
{
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        
        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new CinemaContext();

            if (PasswordOfEmployee.Password == ConfirmPasswordOfEmployee.Password)
            {
                try
                {

                    Employee employee = new Employee
                    {
                        Name = NameOfEmployee.Text,
                        Surname = SurnameOfEmployee.Text,
                        Password = Crypto.Hash(PasswordOfEmployee.Password),
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
