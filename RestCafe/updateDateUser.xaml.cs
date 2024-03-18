using BD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RestCafe
{
    /// <summary>
    /// Логика взаимодействия для updateDateUser.xaml
    /// </summary>
    public partial class updateDateUser : Window
    {
        int id = 0;
        public updateDateUser(int id)
        {
            InitializeComponent();
            this.id = id;
            var user = server.getUser(id);
            for (int i = 0; i < 6; i++)
            {
                (panel.Children[i] as TextBox).Text = user[i];
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Client(id).Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            server.updateUser((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, (panel.Children[5] as TextBox).Text, "1", id);
            MessageBox.Show("Данные успешно сохранены!");
        }
    }
}
