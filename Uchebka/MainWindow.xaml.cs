
using System.Windows;
using Uchebka.DataSet1TableAdapters;

namespace Uchebka
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
            DataFrame.Content = new Page2();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataFrame.Content = new Page3();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataFrame.Content = new Page4();
        }
    }
}
