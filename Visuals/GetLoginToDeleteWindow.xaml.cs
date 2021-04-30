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

namespace ladybug.Visuals
{
    public partial class GetLoginToDeleteWindow : Window
    {
        public GetLoginToDeleteWindow()
        {
            InitializeComponent();
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            var opState = DataManager.RemoveUser(LoginBox.Text);

            if (opState == DataManager.OperationState.NoUserFound)
            {
                MessageBox.Show("Пользователь не был найден");
                return;
            }
            else
            {
                MessageBox.Show("Пользователь был удалён");
            }
               
        }
    }
}
