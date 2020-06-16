using AppBookTrading.View.Page;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AppBookTrading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            Load();
            List<model> arr = new List<model>()
            {
                new model(1, 1, "a"),
                new model(2, 2, "b"),
                new model(3, 3, "c"),
                new model(3, 3, "c")
            };
        }

        private void Load()
        {
            UserControlCart uc = new UserControlCart();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            UserControlCart uc = new UserControlCart();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            UserControlProduct uc = new UserControlProduct();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserControlUser uc = new UserControlUser();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }

        private void btnDoanhSo_Click(object sender, RoutedEventArgs e)
        {
            UserControlStatistical uc = new UserControlStatistical();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }

        private void btnNhapKho_Click(object sender, RoutedEventArgs e)
        {
            UserControlWarehouse uc = new UserControlWarehouse();
            LayoutUserControl.Children.Clear();
            LayoutUserControl.Children.Add(uc);
        }
    }
}
