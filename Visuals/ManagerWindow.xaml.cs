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
    public partial class ManagerWindow : Window
    {
        LessonAKYLAEntities context;

        public ManagerWindow()
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
    }
}
