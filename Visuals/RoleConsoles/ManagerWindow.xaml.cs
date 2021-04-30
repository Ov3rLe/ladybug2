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
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
        }

        private void OnShowData(object sender, RoutedEventArgs e)
        {
            DataWindow w = new DataWindow() { Owner = this };
            w.DataTable.ItemsSource = DataManager.GetUserList();
            w.ShowDialog();
        }
    }
}
