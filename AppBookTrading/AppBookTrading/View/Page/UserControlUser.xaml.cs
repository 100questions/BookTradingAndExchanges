using AppBookTrading.View.Modals;
using DAL_BLL_Tier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

namespace AppBookTrading.View.Page
{
    /// <summary>
    /// Interaction logic for UserControlUser.xaml
    /// </summary>
    public partial class UserControlUser : UserControl
    {
        Ctl_KhachHang ctl_kh = new Ctl_KhachHang();
        Ctl_NhaCungCap ctl_ncc = new Ctl_NhaCungCap();
        Ctl_NhaXuatBan ctl_nxb = new Ctl_NhaXuatBan();
        private NHAXUATBAN_DTO nxb;
        private NHACUNGCAP_DTO ncc;
        public UserControlUser()
        {
            nxb = new NHAXUATBAN_DTO();
            InitializeComponent();
            hideButton();
            Load();
        }

        public async void Load()
        {
            var lstKhachHang = await ctl_kh.GetList();
            dgvKhachHang.ItemsSource = lstKhachHang;
        }

        public async void LoadAgain()
        {
            if (item1.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_kh.GetList();
            }
            if (item2.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_ncc.GetList();
            }
            if (item3.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_nxb.GetList();
            }
        }

        private void hideButton()
        {

            btnSuaNCC.Visibility = Visibility.Collapsed;

            btnSuaNXB.Visibility = Visibility.Collapsed;
        }

        private async void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (item1.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_kh.GetList();
            }
            if (item2.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_ncc.GetList();
            }
            if (item3.IsSelected)
            {
                dgvKhachHang.ItemsSource = await ctl_nxb.GetList();
            }
            hideButton();
        }

        private void dgvKhachHang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (item1.IsSelected)
            //{
            //    try
            //    {
            //        KHACHHANG_DTO ncc = (KHACHHANG_DTO)dgvKhachHang.SelectedValue;
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            if (item2.IsSelected)
            {
                btnThemNCC.Visibility = Visibility.Visible;
                btnSuaNCC.Visibility = Visibility.Visible;
                try
                {
                    ncc = (NHACUNGCAP_DTO)dgvKhachHang.SelectedValue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (item3.IsSelected)
            {
                btnThemNXB.Visibility = Visibility.Visible;
                btnSuaNXB.Visibility = Visibility.Visible;
                try
                {
                    nxb = (NHAXUATBAN_DTO)dgvKhachHang.SelectedValue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        private void btnThemNCC_Click(object sender, RoutedEventArgs e)
        {
            SupplierCreatingWindow frmSupplier = new SupplierCreatingWindow();
            frmSupplier.getState(false);
            frmSupplier.ShowDialog();
        }

        private void btnSuaNCC_Click(object sender, RoutedEventArgs e)
        {
            SupplierCreatingWindow frmSupplier = new SupplierCreatingWindow();
            frmSupplier.getNCC(ncc);
            frmSupplier.getState(true);
            frmSupplier.ShowDialog();
            LoadAgain();
        }

        private void btnThemNXB_Click(object sender, RoutedEventArgs e)
        {
            PublisherCreatingWindow frmPublisher = new PublisherCreatingWindow();
            frmPublisher.getState(false);
            frmPublisher.ShowDialog();
            LoadAgain();
        }

        private void btnSuaNXB_Click(object sender, RoutedEventArgs e)
        {
            PublisherCreatingWindow frmPublisher = new PublisherCreatingWindow();
            frmPublisher.getNXB(nxb);
            frmPublisher.getState(true);
            frmPublisher.ShowDialog();
            LoadAgain();
        }

      
    }
}
