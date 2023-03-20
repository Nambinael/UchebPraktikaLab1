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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        FavDrinkTableAdapter drinks = new FavDrinkTableAdapter();
        public Page3()
        {
            InitializeComponent();
            SecondTable.ItemsSource = drinks.GetData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            drinks.InsertQuery(DrinkNameBox.Text);
            SecondTable.ItemsSource = drinks.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(SecondTable.SelectedValue as DataRowView).Row[0];
            drinks.DeleteQuery(id);
            SecondTable.ItemsSource = drinks.GetData();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SecondTable.SelectedValue != null)
            {
                var item = SecondTable.SelectedItem as DataRowView;
                drinks.UpdateQuery(DrinkNameBox.Text,(int)item.Row[0]);
                SecondTable.ItemsSource = drinks.GetData();

            }
        }

        private void SecondTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SecondTable.SelectedItem != null)
            {
                var item = SecondTable.SelectedItem as DataRowView;
                DrinkNameBox.Text = (string)item.Row[1];
            }
        }
    }
}
