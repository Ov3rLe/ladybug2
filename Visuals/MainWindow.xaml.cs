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

using ladybug.Visuals.Pages;

namespace ladybug.Visuals
{
    public partial class MainWindow : Window
    {
        bool hidden;

        public MainWindow()
        {
            InitializeComponent();
            hidden = false;
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }

        private void ChangeMainPageVisibility()
        {
            if(hidden)
            {
                ButtonPanel.Visibility = Visibility.Visible;
            }
           
            else
            {
                ButtonPanel.Visibility = Visibility.Hidden;
            }

            hidden = !hidden;
        }

        private void OnSignIn(object sender, RoutedEventArgs e)
        {
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new SignInPage());
            ChangeMainPageVisibility();
        }

        private void OnSignUp(object sender, RoutedEventArgs e)
        {
            MainFrame.Visibility = Visibility.Visible;
            MainFrame.Navigate(new SignUpPage());
            ChangeMainPageVisibility();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {  
            MainFrame.Visibility = Visibility.Collapsed;
            if(hidden)
                ChangeMainPageVisibility();
        }
    }
}
