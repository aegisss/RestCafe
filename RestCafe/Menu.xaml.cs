using BD;
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

namespace RestCafe
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        int id = 0;
        public Menu(int id)
        {
            InitializeComponent();
            this.id = id;
            var a = server.getMenuPanel();
            foreach (var b in a)
            {
                Button button = new Button();
                button.Margin = new Thickness(10);
                button.Content = b;
                button.Click += new_order;
                button.Foreground = Brushes.White;
                button.BorderThickness = new Thickness(0);
                button.Background = new SolidColorBrush(Color.FromRgb(188, 60, 180));
                button.Width = 150;
                button.Height = 40;
                button.FontSize = 16;
                panel.Children.Add(button);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Client(id).Show();
            Close();
        }
        void new_order(object sender, RoutedEventArgs e)
        {
            server.createOrder(id, (sender as Button).Content.ToString());
            MessageBox.Show("Заказ создан!");
        }
    }
}
