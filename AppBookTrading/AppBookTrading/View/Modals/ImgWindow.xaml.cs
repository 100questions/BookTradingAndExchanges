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

namespace AppBookTrading.View.Modals
{
    /// <summary>
    /// Interaction logic for ImgWindow.xaml
    /// </summary>
    public partial class ImgWindow : Window
    {
        public ImgWindow()
        {
            InitializeComponent();
        }

        public void getIMG(string IMG)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(IMG);
            bitmap.EndInit();
            ImageViewer1.Source = bitmap;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
