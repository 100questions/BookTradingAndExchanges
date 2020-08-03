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

namespace AppBookTrading
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        Ctl_NguoiDung ctl_nd = new Ctl_NguoiDung();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUserName.Text) && !String.IsNullOrEmpty(pbxPassword.Password))
            {
                NGUOIDUNG_DTO nd = await ctl_nd.GetUerAsync(txtUserName.Text, pbxPassword.Password.ToString());
                if (nd.MANV is null)
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác");
                }
                else
                {
                    this.Hide();
                    MainWindow frmMain = new MainWindow(nd);
                    frmMain.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill the blank");
            }
        }

    }
}
