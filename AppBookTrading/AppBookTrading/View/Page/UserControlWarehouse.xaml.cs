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
        Ctl_NhaCungCap ctl_ncc = new Ctl_NhaCungCap();
        PHIEUNHAPSACH_DTO pns;
        public NGUOIDUNG_DTO nd;
        public UserControlWarehouse()
        {
            InitializeComponent();
            LoadPNS();
            LoadNCC();
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



        public async void LoadNCC()
        {
            var lstNhaCungCap = await ctl_ncc.GetList();
            cbbNhaCungCap.ItemsSource = lstNhaCungCap;
            cbbNhaCungCap.SelectedValuePath = "MANCC";
            cbbNhaCungCap.DisplayMemberPath = "TENNCC";
            cbbNhaCungCap.SelectedIndex = 0;
        }

        public async void LoadPNS()
        {
            var lstPhieuNhapSach = await ctl.GetList();
            dgvPhieuNhapSach.ItemsSource = lstPhieuNhapSach;
        }

        private void btnTaoPhieuNhap_Click(object sender, RoutedEventArgs e)
        {
            ImportCreatingWindow Icw = new ImportCreatingWindow();
            Icw.maNCC = cbbNhaCungCap.SelectedValue.ToString(); 
            Icw.maNV = nd.MANV;
            Icw.ShowDialog();
            LoadPNS();
        }

        private void btnXemPhieuNhap_Click(object sender, RoutedEventArgs e)
        {
            if(pns != null)
            {
                ImportDetailsWindow Idw = new ImportDetailsWindow();
                Idw.getCTPN(pns.MAPHIEU);
                Idw.ShowDialog();
                LoadPNS();
            }
            else
            {
                MessageBox.Show("Hãy chọn một phiếu nhập!");
            }
        }

        private void btnThemNhaCungCap_Click(object sender, RoutedEventArgs e)
        {
            SupplierCreatingWindow Sc = new SupplierCreatingWindow();
            Sc.getState(false);
            Sc.ShowDialog();
            LoadNCC();
        }
    }
}
