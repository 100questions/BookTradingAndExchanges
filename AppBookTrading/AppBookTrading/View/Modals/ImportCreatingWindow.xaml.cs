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
    /// Interaction logic for ImportCreatingWindow.xaml
    /// </summary>
    public partial class ImportCreatingWindow : Window
    {
        public string maNV = String.Empty;
        public string maNCC = String.Empty;
        private double thanhTien;
        Ctl_Sach ctl_sach = new Ctl_Sach();
        Ctl_PhieuNhapSach ctl_pns = new Ctl_PhieuNhapSach();
        Ctl_ChiTietPhieuNhap ctl_ctpns = new Ctl_ChiTietPhieuNhap();
        public ImportCreatingWindow()
        {
            InitializeComponent();
            load();
        }

        private async void load()
        {
            btnXoa.Visibility = Visibility.Collapsed;
            txtMaPhieuNhap.IsEnabled = false;
            Guid g = Guid.NewGuid();
            txtMaPhieuNhap.Text = g.ToString();
            var lstSach = await ctl_sach.GetList();
            cbbSanPham.ItemsSource = lstSach;
            cbbSanPham.SelectedValuePath = "MASACH";
            cbbSanPham.DisplayMemberPath = "TENSACH";
            cbbSanPham.SelectedIndex = 0;
        }

        private async void loadDGV()
        {
            dgvCT_PhieuNhap.ItemsSource = await ctl_ctpns.Get(txtMaPhieuNhap.Text);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvCT_PhieuNhap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnXoa.Visibility = Visibility.Visible;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            PHIEUNHAPSACH_DTO pns = new PHIEUNHAPSACH_DTO();
            pns.MAPHIEU = txtMaPhieuNhap.Text;
            pns.MANCC = maNCC;
            pns.MANV = maNV;
            pns.NGAYNHAP = DateTime.Now;
            pns.THANHTIENPHIEUNHAP = thanhTien;
            try
            {
                ctl_pns.AddAsync(pns);
                MessageBox.Show("Nhập hàng thành công!");
            }
            catch
            {
                MessageBox.Show("Lỗi khi nhập hàng!");
            }
        }
    }
}
