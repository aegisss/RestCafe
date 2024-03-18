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
using BD;

namespace RestCafe
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text.Equals("") || password.Text.Equals(""))
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButton.OK,MessageBoxImage.Error);
                return;
            }
            string role = "";
            int id = -1;
            if (server.Auth(login.Text, password.Text,out role, out id))
                switch (role)
                {
                    case "client":
                        new Client(id).Show();
                        Close();
                        break;
                    case "manager":
                        new ManagerWindow().Show();
                        Close();
                        break;
                    case "oficiant":
                        new Oficiant().Show();
                        Close();
                        break;

                }
            else MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Reg().Show();
            Close();
        }
    }
}
