using System;
using System.Windows;
using DAL_BLL_Tier;

namespace AppBookTrading.View.Modals
{
    /// <summary>
    /// Interaction logic for PublisherCreatingWindow.xaml
    /// </summary>
    public partial class PublisherCreatingWindow : Window
    {
        Ctl_NhaXuatBan ctl = new Ctl_NhaXuatBan();
        private NHAXUATBAN_DTO nxbBind;
        public PublisherCreatingWindow()
        {
            InitializeComponent();
            txtMaNXB.IsEnabled = false;
           
        }

        public void getState(bool state)
        {
            if (state)
            {
                loadNXB(nxbBind);
            }
            else
            {
                generateMaNXB();
            }
        }

        public void getNXB(NHAXUATBAN_DTO nxb)
        {
            nxbBind = nxb;
        }

        private void generateMaNXB()
        {
            Guid g = Guid.NewGuid();
            txtMaNXB.Text = g.ToString();
        }

        private void loadNXB(NHAXUATBAN_DTO nxb)
        {
            txtMaNXB.Text = nxb.MANXB;
            txtTenNXB.Text = nxb.TENNXB;
            txtDiaChi.Text = nxb.DIACHI;
            txtSDT.Text = nxb.SDT;
        }


        private bool checkEmptyBox()
        {
            if (string.IsNullOrEmpty(txtTenNXB.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà xuất bản");
                return false;
            }
            else if(string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa  chỉ nhà xuất bản");
                return false;
            }
            else if(string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà xuất bản");
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            nxbBind = null;
            this.Close();
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmptyBox())
            {
                NHAXUATBAN_DTO nxb = new NHAXUATBAN_DTO();
                nxb.MANXB = txtMaNXB.Text;
                nxb.TENNXB = txtTenNXB.Text;
                nxb.DIACHI = txtDiaChi.Text;
                nxb.SDT = txtSDT.Text;
                if (nxbBind != null)
                {
                    try
                    {
                        ctl.UpdateAsync(nxbBind);
                        MessageBox.Show("Cập nhật nhà xuất bản thành công!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi cập nhật nhà xuất bản!");
                    }
                }
                else
                {
                    try
                    {
                        ctl.AddPublisherAsync(nxb);
                        MessageBox.Show("Thêm nhà xuất bản thành công!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi thêm nhà xuất bản!");
                    }
                }
            }
        }
    }
}
