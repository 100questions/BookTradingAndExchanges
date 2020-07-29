using DAL_BLL_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for BillDetailsWindow.xaml
    /// </summary>
    public partial class BillDetailsWindow : Window
    {
        Ctl_ChitTietHoaDon ctl_cthd = new Ctl_ChitTietHoaDon();
        public BillDetailsWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public async void getBillDetails(string maHD)
        {
            dgvCTHD.ItemsSource = await ctl_cthd.Get(maHD);
        }

    }
}
