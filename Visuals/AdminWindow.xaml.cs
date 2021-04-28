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

using System.IO;
using ladybug.EF;

namespace ladybug.Visuals
{
    public partial class AdminWindow : Window
    {
        LessonAKYLAEntities context;

        public AdminWindow()
        {
            InitializeComponent();
            context = new LessonAKYLAEntities();
        }

        private void OnShowData(object sender, RoutedEventArgs e)
        {
            DataWindow w = new DataWindow() { Owner = this };
            w.DataTable.ItemsSource = context.User.ToList();
            w.ShowDialog();
        }

        private void SaveNewUser(User user)
        {
            context.User.Add(user);
            context.SaveChanges();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            CreateUserWindow w = new CreateUserWindow() { Owner = this };
            w.ShowDialog();

            if (w.NewUser.UserID == -1)
                return;

            SaveNewUser(w.NewUser);
        }

        private void OnRemoveUser(object sender, RoutedEventArgs e)
        {

        }
    }
}
