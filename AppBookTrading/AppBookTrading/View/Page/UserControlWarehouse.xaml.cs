using AppBookTrading.View.Modals;
using DAL_BLL_Tier;
using System;
using System.Windows;
using System.Windows.Controls;

namespace AppBookTrading.View.Page
{
    /// <summary>
    /// Interaction logic for UserControlWarehouse.xaml
    /// </summary>
    public partial class UserControlWarehouse : UserControl
    {
        Ctl_PhieuNhapSach ctl = new Ctl_PhieuNhapSach();
        PHIEUNHAPSACH_DTO pns;
        public UserControlWarehouse()
        {
            InitializeComponent();
            Load();
        }

        private void dgvPhieuNhapSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                pns = (PHIEUNHAPSACH_DTO)dgvPhieuNhapSach.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public async void Load()
        {
            var lstPhieuNhapSach = await ctl.GetList();
            dgvPhieuNhapSach.ItemsSource = lstPhieuNhapSach;
        }

        private void btnTaoPhieuNhap_Click(object sender, RoutedEventArgs e)
        {
            ImportCreatingWindow Icw = new ImportCreatingWindow();
            Icw.ShowDialog();
        }

        private void btnXemPhieuNhap_Click(object sender, RoutedEventArgs e)
        {
            if(pns != null)
            {
                ImportDetailsWindow Idw = new ImportDetailsWindow();
                Idw.getCTPN(pns.MAPHIEU);
                Idw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy chọn một phiếu nhập!");
            }
        }
    }
}
