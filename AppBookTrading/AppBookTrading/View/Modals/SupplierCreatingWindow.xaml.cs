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
    /// Interaction logic for SupplierCreatingWindow.xaml
    /// </summary>
    public partial class SupplierCreatingWindow : Window
    {
        Ctl_NhaCungCap ctl = new Ctl_NhaCungCap();
        private NHACUNGCAP_DTO nccBind;
        public SupplierCreatingWindow()
        {
            InitializeComponent();
            txtMaNCC.IsEnabled = false;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void getState(bool state)
        {
            if (state)
            {
                loadNXB(nccBind);
            }
            else
            {
                generateMaNXB();
            }
        }

        public void getNCC(NHACUNGCAP_DTO ncc)
        {
            nccBind = ncc;
        }

        private void generateMaNXB()
        {
            Guid g = Guid.NewGuid();
            txtMaNCC.Text = g.ToString();
        }

        private void loadNXB(NHACUNGCAP_DTO ncc)
        {
            txtMaNCC.Text = ncc.MANCC;
            txtTenNCC.Text = ncc.TENNCC;
            txtDiaChi.Text = ncc.DIACHI;
            txtSDT.Text = ncc.SDT;
        }


        private bool checkEmptyBox()
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp");
                return false;
            }
            else if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa  chỉ nhà cung cấp");
                return false;
            }
            else if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (checkEmptyBox())
            {
                NHACUNGCAP_DTO ncc = new NHACUNGCAP_DTO();
                ncc.MANCC = txtMaNCC.Text;
                ncc.TENNCC = txtTenNCC.Text;
                ncc.DIACHI = txtDiaChi.Text;
                ncc.SDT = txtSDT.Text;
                if (nccBind != null)
                {
                    try
                    {
                        ctl.UpdateAsync(ncc);
                        MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi cập nhật nhà cung cấp!");
                    }
                }
                else
                {
                    try
                    {
                        ctl.AddAsync(ncc);
                        MessageBox.Show("Thêm nhà cung cấp thành công!");
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi khi thêm nhà cung cấp!");
                    }
                }
            }
        }

    }
}
