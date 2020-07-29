using DAL_BLL_Tier;
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
    /// Interaction logic for ImportDetailsWindow.xaml
    /// </summary>
    public partial class ImportDetailsWindow : Window
    {
        Ctl_ChiTietPhieuNhap ctl_ctpn = new Ctl_ChiTietPhieuNhap();
        public ImportDetailsWindow()
        {
            InitializeComponent();
        }

        public async void getCTPN(string maPN)
        {
            dgvCTPN.ItemsSource = await ctl_ctpn.Get(maPN);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
