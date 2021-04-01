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

namespace ladybug.Visuals
{
    public partial class MainWindow : Window
    {
        string DataPath = ".\\Data";
        UserDataManager DataManager;

        public MainWindow()
        {
            InitializeComponent();

            DataManager = new UserDataManager(DataPath);
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameBox.Text;
            string lastName = LastNameBox.Text;
            int age;

            if(String.IsNullOrWhiteSpace(firstName))
            {
                MessageBox.Show("Введите ваше имя");
                return;
            }

            if (HasOrdinal(firstName))
            {
                MessageBox.Show("Имя может содержать только буквы");
                return;
            }

            if (String.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Введите вашу фамилию");
                return;
            }

            if (HasOrdinal(lastName))
            {
                MessageBox.Show("Фамилия может содержать только буквы");
                return;
            }

            if (String.IsNullOrWhiteSpace(AgeBox.Text))
            {
                MessageBox.Show("Введите ваш возраст");
                return;
            }

            if (!Int32.TryParse(AgeBox.Text, out age))
            {
                MessageBox.Show("Возраст может содержать только цифры");
                return;
            }

            else if(age <= 0)
            {
                MessageBox.Show("Возраст должен быть положительным числом");
                return;
            }

            MessageBox.Show($"Здравствуйте {lastName} {firstName}, {age} лет!");
            SaveToFile(firstName, lastName, age);
        }
       

        private bool HasOrdinal(string s)
        {
            int tmp;
            foreach (char c in s)
            {
                if (Int32.TryParse(c.ToString(), out tmp))
                    return true;
            }

            return false;
        }

        private void SaveToFile(string firstName, string lastName, int age)
        {
            DataManager.AddUser(new UserData() { FirstName = firstName, LastName = lastName, Age = age });
        }

        private void OnShowData(object sender, RoutedEventArgs e)
        {
            DataWindow w = new DataWindow() { Owner = this };
            w.DataTable.ItemsSource = DataManager.RestoreData();
            w.ShowDialog();
        }
    }
}
