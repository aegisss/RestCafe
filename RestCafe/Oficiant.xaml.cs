using BD;
using System;
using System.Collections;
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
    /// Логика взаимодействия для Oficiant.xaml
    /// </summary>
    public partial class Oficiant : Window
    {
        public Oficiant()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Read("Заказы", new Func<string,string,string,string,string,int, IEnumerable>(server.updateOrder), new Func<int, IEnumerable>(server.deleteOrder), new Func<string, string, string, string, string, IEnumerable>(server.createOrders), new Func<IEnumerable>(server.getOrders), new Func<bool>(exit), server.getColumnsOrders()).Show();
            Close();

        }



        bool exit() { new Oficiant().Show(); return true; }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new Read("Столики", new Func<string, string, int, IEnumerable>(server.updateTable), new Func<int, IEnumerable>(server.deleteTable), new Func<string, string, IEnumerable>(server.createTable), new Func<IEnumerable>(server.getTabless), new Func<bool>(exit), server.getColumnsTable()).Show();
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new Read("Меню", new Func<string, string, string, int, IEnumerable>(server.updateMenu), new Func<int, IEnumerable>(server.deleteMenu), new Func<string, string, string, IEnumerable>(server.createMenu), new Func<IEnumerable>(server.getMenu), new Func<bool>(exit), server.getColumnsMenu()).Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
    }
}
