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
        public UserControlUser()
        {
            InitializeComponent();
            Load();
        }

        public async void Load()
        {
            var lstKhachHang = await ctl_kh.GetList();
            dgvKhachHang.ItemsSource = lstKhachHang;
        }

        private void dgvKhachHang_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                KHACHHANG_DTO str = (KHACHHANG_DTO)dgvKhachHang.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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
        }
    }
}
