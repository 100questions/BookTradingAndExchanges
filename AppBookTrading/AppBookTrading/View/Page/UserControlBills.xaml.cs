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

    public partial class UserControlBills : UserControl
    {
        Ctl_HoaDon hoadon_ctl = new Ctl_HoaDon();
        public UserControlBills()
        {
            InitializeComponent();
            Load();
        }

        private void dgvHoaDon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                HOADON_DTO str = (HOADON_DTO)dgvHoaDon.SelectedItem;
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
        }

    }
}
