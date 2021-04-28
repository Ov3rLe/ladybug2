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
using System.Windows.Shapes;

using ladybug.EF;

namespace ladybug.Visuals
{
    public partial class CreateUserWindow : Window
    {
        public User NewUser;
        public bool validUser;

        enum Gender
        {
            Male,
            Female
        }

        enum Role
        {
            Admin,
            Manager,
            Guest
        }

        public CreateUserWindow()
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

            NewUser = new User()
            {
                Login = login,
                Password = password,
                Email = email,
                PhoneNumber = phoneNumber,
                GenderID = (bool)MaleBox.IsChecked ? (int)Gender.Male : (int)Gender.Female,
                RoleID = (int)Role.Guest,
            };

            validUser = true;
            this.Close();
        }

        private void Window_Closing(object sender, EventArgs e)
        {
            if (!validUser)
                NewUser = new User { UserID = -1 };
        }
    }
}
