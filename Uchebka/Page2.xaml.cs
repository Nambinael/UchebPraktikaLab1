﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        ChelovekTableAdapter chelovek = new ChelovekTableAdapter();
        FavDrinkTableAdapter drinks = new FavDrinkTableAdapter();
        AgeGroupTableAdapter age = new AgeGroupTableAdapter();
        public Page2()
        {
            InitializeComponent();

            FirstTable.ItemsSource = chelovek.GetData();
            FavDrinkIdBox.ItemsSource = drinks.GetData();
            AgeGroupIdBox.ItemsSource = age.GetData();
            FavDrinkIdBox.DisplayMemberPath = "NameOfDrink";
            FavDrinkIdBox.SelectedValuePath = "Id";
            AgeGroupIdBox.DisplayMemberPath = "NameOfAgeGroup";
            AgeGroupIdBox.SelectedValuePath = "Id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)FavDrinkIdBox.SelectedValue;
            int id1 = (int)AgeGroupIdBox.SelectedValue;
            chelovek.InsertQuery(NaaameBox.Text, id, id1);
            FirstTable.ItemsSource = chelovek.GetData();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = (int)(FirstTable.SelectedValue as DataRowView).Row[0];
            chelovek.DeleteQuery(id);
            FirstTable.ItemsSource = chelovek.GetData();
        }

        private void FirstTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FirstTable.SelectedItem != null)
            {
                var item = FirstTable.SelectedItem as DataRowView;
                NaaameBox.Text = (string)item.Row[1];
                FavDrinkIdBox.SelectedValue = (int)item.Row[2];
                AgeGroupIdBox.SelectedValue = (int)item.Row[3];
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstTable.SelectedValue != null)
            {
                var item = FirstTable.SelectedItem as DataRowView;
                chelovek.UpdateQuery(NaaameBox.Text, (int)FavDrinkIdBox.SelectedValue,(int)AgeGroupIdBox.SelectedValue, (int)item.Row[0]);
                FirstTable.ItemsSource = chelovek.GetData();
            }
        }
    }
}
