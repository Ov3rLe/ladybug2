using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ladybug.EF;
using ladybug.Misc; 

namespace ladybug.Visuals.Pages
{
    public partial class SignUpPage : Page
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string email = EmailBox.Text;
            string password = PassBox.Password;
            string phoneNumber = PhoneNumberBox.Text;

            if (String.IsNullOrWhiteSpace(login))
            {
                MessageBox.Show("Введите логин");
                return;
            }

            if (String.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Введите пароль");
                return;
            }

            if (!(bool)MaleBox.IsChecked && !(bool)FemaleBox.IsChecked)
            {
                MessageBox.Show("Выберите пол");
                return;
            }

            var opStatus = DataManager.AddUser(new User()
            {
                Login = login,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                GenderID = (bool)MaleBox.IsChecked ? (int)GenderCode.Male : (int)GenderCode.Female,
                RoleID = (int)RoleCode.Guest,
            });

            if (opStatus == DataManager.OperationState.Duplicate)
                MessageBox.Show("Пользователь с таким логином уже существует");

            else
                MessageBox.Show("Добро пожаловать!");
        }
    }
}
