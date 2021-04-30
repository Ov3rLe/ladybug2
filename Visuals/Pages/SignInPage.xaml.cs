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
using ladybug.Visuals.RoleConsoles;

namespace ladybug.Visuals.Pages
{
    public partial class SignInPage : Page
    {
        LessonAKYLAEntities context;

        public SignInPage()
        {
            InitializeComponent();
            context = new LessonAKYLAEntities();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PassBox.Password;

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

            User foundUser;
            if (userExists(login, out foundUser))
            {
                if (correctPassword(foundUser, password))
                {
                    switch (foundUser.RoleID)
                    {
                        case (int)RoleCode.Admin:
                            new AdminWindow().ShowDialog();
                            break;

                        case (int)RoleCode.Manager:
                            new ManagerWindow().ShowDialog();
                            break;

                        case (int)RoleCode.Guest:
                            new GuestConsole(login).ShowDialog();
                            break;

                        default:
                            break;
                    }
                }

                else
                    MessageBox.Show("Неверный пароль");
            }

            else
                MessageBox.Show("Пользователь не найден");

        }

        private bool userExists(string login, out User user)
        {
            user = context.User.ToList().Find((e) => e.Login == login);
            return user != null;
        }

        private bool correctPassword(User user, string password)
        {
            return user.Password == password;
        }
    }
}
