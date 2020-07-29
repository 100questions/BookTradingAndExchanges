using DAL_BLL_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AppBookTrading.View.Modals;

namespace AppBookTrading.View.Page
{

    public partial class UserControlBills : UserControl
    {
        Ctl_HoaDon hoadon_ctl = new Ctl_HoaDon();
        HOADON_DTO hd;
        public UserControlBills()
        {
            InitializeComponent();
            Load();
        }

        private void dgvHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                hd = (HOADON_DTO)dgvHoaDon.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public async void Load()
        {
            var lstHoaDon = await hoadon_ctl.GetList();
            dgvHoaDon.ItemsSource = lstHoaDon;

            String[] lstTrangThai = { "Tạm Giữ", "Đang Vận Chuyển", "Đã Giao", "Đã Huỷ" };
            cbbTrangThai.ItemsSource = lstTrangThai;
            cbbTrangThai.SelectedIndex = 0;

        }


        private async void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if (btnTimKiem.Content.Equals("Tìm Kiếm"))
            {
                btnTimKiem.Content = "Huỷ Tìm";
                var lst = await hoadon_ctl.GetList();
                DateTime? dateFrom = dpFrom.SelectedDate;
                DateTime? dateTo = dpTo.SelectedDate;
                List<HOADON_DTO> lstHD = new List<HOADON_DTO>();
                if (dateFrom.HasValue && dateTo.HasValue)
                {
                    string sDateFrom = dateFrom.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    string sDateTo = dateTo.Value.ToString("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    lstHD = (List<HOADON_DTO>) lst.Where(t => !String.IsNullOrEmpty(t.NGAYLAPHD.ToString())).Where(t => DateTime.Parse(t.NGAYLAPHD.ToString()) >= dateFrom && DateTime.Parse(t.NGAYLAPHD.ToString()) >= dateTo).ToList();
                    dgvHoaDon.ItemsSource = lstHD;
                }                
                if (!String.IsNullOrEmpty(txtTimKiem.ToString()) && lstHD.Count > 0)
                {
                    dgvHoaDon.ItemsSource = lstHD.Where(t => !String.IsNullOrEmpty(t.MAKH) && !String.IsNullOrEmpty(t.MAHD)).Where(t => t.MAHD.ToLower().Contains(txtTimKiem.Text.ToLower()) || t.MAKH.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
                }
                else
                {
                    dgvHoaDon.ItemsSource = lst.Where(t => !String.IsNullOrEmpty(t.MAKH) && !String.IsNullOrEmpty(t.MAHD)).Where(t => t.MAHD.ToLower().Contains(txtTimKiem.Text.ToLower()) || t.MAKH.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
                }
                return;
            }

            if (btnTimKiem.Content.ToString().Equals("Huỷ Tìm"))
            {
                btnTimKiem.Content = "Tìm Kiếm";
                txtTimKiem.Clear();
                dgvHoaDon.ItemsSource = await hoadon_ctl.GetList();
            }
        }

        private void XemHoaDon_Click(object sender, RoutedEventArgs e)
        {
            if (hd != null)
            {
                BillDetailsWindow bdw = new BillDetailsWindow();
                bdw.getBillDetails(hd.MAHD);
                bdw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hãy chọn một hoá đơn!");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(hd != null)
            {
                hd.TRANGTHAI = cbbTrangThai.SelectedValue.ToString();
                try
                {
                    hd = await hoadon_ctl.UpadateAsync(hd);
                    MessageBox.Show("Cập nhật hoá đơn thành công");
                }
                catch
                {
                    MessageBox.Show("Cập nhật hoá đơn thất bại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hoá đơn trước khi cập nhật");
            }
        }
    }
}
