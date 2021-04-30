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

namespace ladybug.Visuals.RoleConsoles
{
    public partial class GuestConsole : Window
    {
        public GuestConsole(string login)
        {
            InitializeComponent();
            var user = DataManager.GetUserList().Find((e) => e.Login == login);

            UserDataTextBox.Text = $"Login: {user.Login}\nPassword: {user.Password}\n" +
                $"Email: {user.Email}\nPhone number: {user.PhoneNumber}\n" +
                $"Role: {user.Role.RoleName}\nGender: {user.Gender.GenderName}";
            
        }
    }
}
