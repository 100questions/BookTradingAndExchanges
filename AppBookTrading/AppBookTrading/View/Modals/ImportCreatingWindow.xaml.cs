using DAL_BLL_Tier;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AppBookTrading.View.Modals
{
    /// <summary>
    /// Interaction logic for ImportCreatingWindow.xaml
    /// </summary>
    public partial class ImportCreatingWindow : Window
    {
        public string maNV = String.Empty;
        public string maNCC = String.Empty;
        private List<CT_PHIEUNHAPSACH_DTO> lstCTPN;
        Ctl_Sach ctl_sach = new Ctl_Sach();
        Ctl_PhieuNhapSach ctl_pns = new Ctl_PhieuNhapSach();
        Ctl_ChiTietPhieuNhap ctl_ctpns = new Ctl_ChiTietPhieuNhap();
        public ImportCreatingWindow()
        {
            InitializeComponent();
            lstCTPN = new List<CT_PHIEUNHAPSACH_DTO>();
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

        private void loadSaveDGV()
        {
            dgvCT_PhieuNhap.ItemsSource = lstCTPN;
            dgvCT_PhieuNhap.Items.Refresh();
            
        }

        private bool checkSanPhamTrung(string maSP)
        {
            for(int i = 0; i < lstCTPN.Count; i++)
            {
                if (maSP.Equals(lstCTPN[i].MASACH))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgvCT_PhieuNhap_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnXoa.Visibility = Visibility.Visible;
        }

        private async void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if(lstCTPN.Count > 0) {
                PHIEUNHAPSACH_DTO pns = new PHIEUNHAPSACH_DTO();
                pns.MANCC = maNCC;
                pns.MAPHIEU = txtMaPhieuNhap.Text;
                pns.MANV = maNV;
                pns.NGAYNHAP = DateTime.Now;
                try
                {
                    ctl_pns.AddAsync(pns);
                    for (int i = 0; i < lstCTPN.Count; i++)
                    {
                        try
                        {
                            ctl_ctpns.AddAsync(lstCTPN[i]);
                        }
                        catch
                        {
                            MessageBox.Show("Lỗi khi thêm chi tiết hoá đơn");
                        }
                    }
                    MessageBox.Show("Nhập hàng thành công!");
                }
                catch
                {
                    MessageBox.Show("Lỗi khi nhập hàng!");
                }
            }
            else
            {
                MessageBox.Show("Chưa thêm sản phẩm để nhập");
            }
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSoLuong.Text))
            {
                if (checkSanPhamTrung(cbbSanPham.SelectedValue.ToString()))
                {
                    CT_PHIEUNHAPSACH_DTO ctpn = new CT_PHIEUNHAPSACH_DTO();
                    ctpn.MAPHIEU = txtMaPhieuNhap.Text;
                    ctpn.MASACH = cbbSanPham.SelectedValue.ToString();
                    ctpn.SLNHAP = int.Parse(txtSoLuong.Text);
                    lstCTPN.Add(ctpn);
                    loadSaveDGV();
                }
                else
                {
                    MessageBox.Show("Sẩn phẩm đã được thêm!");
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập số lượng!");
            }
        }
    }
}
