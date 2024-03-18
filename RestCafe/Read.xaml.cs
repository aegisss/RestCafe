using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RestCafe
{
    public partial class Read : Window
    {
        Delegate update, delete, create, exit, set;
        List<string> tmp = new List<string>();

        private void data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((data.SelectedItem as DataRowView) != null)
            {
                switch (tmp.Count - 1)
                {
                    case 1:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        break;
                    case 2:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        break;
                    case 3:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        (panel.Children[2] as TextBox).Text = (data.SelectedItem as DataRowView)[3].ToString();
                        break;
                    case 4:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        (panel.Children[2] as TextBox).Text = (data.SelectedItem as DataRowView)[3].ToString();
                        (panel.Children[3] as TextBox).Text = (data.SelectedItem as DataRowView)[4].ToString();
                        break;
                    case 5:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        (panel.Children[2] as TextBox).Text = (data.SelectedItem as DataRowView)[3].ToString();
                        (panel.Children[3] as TextBox).Text = (data.SelectedItem as DataRowView)[4].ToString();
                        (panel.Children[4] as TextBox).Text = (data.SelectedItem as DataRowView)[5].ToString();
                        break;
                    case 6:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        (panel.Children[2] as TextBox).Text = (data.SelectedItem as DataRowView)[3].ToString();
                        (panel.Children[3] as TextBox).Text = (data.SelectedItem as DataRowView)[4].ToString();
                        (panel.Children[4] as TextBox).Text = (data.SelectedItem as DataRowView)[5].ToString();
                        (panel.Children[5] as TextBox).Text = (data.SelectedItem as DataRowView)[6].ToString();
                        break;
                    case 7:
                        (panel.Children[0] as TextBox).Text = (data.SelectedItem as DataRowView)[1].ToString();
                        (panel.Children[1] as TextBox).Text = (data.SelectedItem as DataRowView)[2].ToString();
                        (panel.Children[2] as TextBox).Text = (data.SelectedItem as DataRowView)[3].ToString();
                        (panel.Children[3] as TextBox).Text = (data.SelectedItem as DataRowView)[4].ToString();
                        (panel.Children[4] as TextBox).Text = (data.SelectedItem as DataRowView)[5].ToString();
                        (panel.Children[5] as TextBox).Text = (data.SelectedItem as DataRowView)[6].ToString();
                        (panel.Children[6] as TextBox).Text = (data.SelectedItem as DataRowView)[7].ToString();
                        break;
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            switch (tmp.Count - 1)
            {
                case 1:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 2:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 3:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 4:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 5:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 6:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, (panel.Children[6] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
                case 7:
                    update.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, (panel.Children[5] as TextBox).Text, (panel.Children[6] as TextBox).Text, Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                    break;
            }
            data.ItemsSource = null;
            data.ItemsSource = (IEnumerable)set.DynamicInvoke();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var a in panel.Children)
                if ((a as TextBox).Text == "")
                {
                    MessageBox.Show("Не все поля заполнены");
                    return;
                }
            switch (tmp.Count-1)
            {
                case 1:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text);
                    break;
                case 2:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text);
                    break;
                case 3:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text);
                    break;
                case 4:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text);
                    break;
                case 5:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text);
                    break;
                case 6:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, (panel.Children[5] as TextBox).Text);
                    break;
                case 7:
                    create.DynamicInvoke((panel.Children[0] as TextBox).Text, (panel.Children[1] as TextBox).Text, (panel.Children[2] as TextBox).Text, (panel.Children[3] as TextBox).Text, (panel.Children[4] as TextBox).Text, (panel.Children[5] as TextBox).Text,(panel.Children[6] as TextBox).Text);
                    break;
            }
            data.ItemsSource = null;
            data.ItemsSource = (IEnumerable)set.DynamicInvoke();
        }

        public Read(string title,Delegate update, Delegate delete, Delegate create, Delegate set, Delegate exit, List<string> columns)
        {
            InitializeComponent();
            this.title.Text = title;
            this.update = update;
            this.delete = delete;
            this.create = create;
            this.exit = exit;
            this.set = set;
            data.ItemsSource = (IEnumerable)set.DynamicInvoke();
            for (int i = 0; i < columns.Count-1; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Height = 40;
                textBox.Margin = new Thickness(0, 10, 0, 10);
                panel.Children.Add(textBox);
            }
            tmp = columns;


        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            if (data.SelectedItem != null)
            {
                delete.DynamicInvoke(Convert.ToInt32((data.SelectedItem as DataRowView)[0]));
                data.ItemsSource = null;
                data.ItemsSource = (IEnumerable)set.DynamicInvoke();
            }
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            exit.DynamicInvoke();
            Close();
        }
    }
}
