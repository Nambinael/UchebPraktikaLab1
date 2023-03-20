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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Uchebka.DataSet1TableAdapters;

namespace Uchebka
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        AgeGroupTableAdapter age = new AgeGroupTableAdapter();
        public Page4()
        {
            InitializeComponent();
            ThirdTable.ItemsSource = age.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            age.InsertQuery(AgeGroupBox.Text);
            ThirdTable.ItemsSource = age.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(ThirdTable.SelectedValue as DataRowView).Row[0];
            age.DeleteQuery(id);
            ThirdTable.ItemsSource = age.GetData();
        }

        private void ThirdTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThirdTable.SelectedItem != null)
            {
                var item = ThirdTable.SelectedItem as DataRowView;
                AgeGroupBox.Text = (string)item.Row[1];
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ThirdTable.SelectedValue != null)
            {
                var item = ThirdTable.SelectedItem as DataRowView;
                age.UpdateQuery(AgeGroupBox.Text, (int)item.Row[0]);
                ThirdTable.ItemsSource = age.GetData();

            }
        }
    }
}
