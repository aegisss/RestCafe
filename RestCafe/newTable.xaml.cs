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
    /// Логика взаимодействия для newTable.xaml
    /// </summary>
    public partial class newTable : Window
    {
        int id = 0;
        public newTable(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (date1.SelectedDate.Value.ToShortDateString() != "" && date2.SelectedDate.Value.ToShortDateString() != "") server.createReserved(date1.SelectedDate.Value.ToShortDateString(), date2.SelectedDate.Value.ToShortDateString());
            MessageBox.Show("Бронь прошла успешно!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Client(id).Show();
            Close();
        }
    }
}
