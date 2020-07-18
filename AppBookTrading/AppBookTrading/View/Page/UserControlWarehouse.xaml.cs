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
    /// Interaction logic for UserControlWarehouse.xaml
    /// </summary>
    public partial class UserControlWarehouse : UserControl
    {
        Ctl_PhieuNhapSach ctl = new Ctl_PhieuNhapSach();
        public UserControlWarehouse()
        {
            InitializeComponent();
            Load();
        }

        private void dgvPhieuNhapSach_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                PHIEUNHAPSACH_DTO str = (PHIEUNHAPSACH_DTO)dgvPhieuNhapSach.SelectedItem;
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
    }
}
