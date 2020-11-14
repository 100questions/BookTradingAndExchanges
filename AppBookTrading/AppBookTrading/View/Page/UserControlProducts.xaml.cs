using AppBookTrading.View.Modals;
using DAL_BLL_Tier;
using Microsoft.Win32;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AppBookTrading.View.Page
{
    /// <summary>
    /// Interaction logic for UserControlProduct.xaml
    /// </summary>
    public partial class UserControlProduct : UserControl
    {
        //StorageCredentials credentials = new StorageCredentials(accountName, accountKey);
        //CloudStorageAccount storageAccount = new CloudStorageAccount(credentials, useHttps: true);
        Ctl_Sach ctl = new Ctl_Sach();
        Ctl_LoaiSach ctl_ls = new Ctl_LoaiSach();
        Ctl_NhaXuatBan ctl_nxb = new Ctl_NhaXuatBan();
        public UserControlProduct()
        {

            InitializeComponent();
            txtMaSP.IsEnabled = false;
            txtImageURL.IsEnabled = false;
            disableText();
            btnLuu.Visibility = Visibility.Collapsed;
            btnHuy.Visibility = Visibility.Collapsed;
            Load();         
            
        }

        public async void Load()
        {             
            String[] lstTrangThai = { "Đang kinh doanh", "Hết hàng", "Ngừng kinh doanh"};
            cbbTrangThai.ItemsSource = lstTrangThai ;
            cbbTrangThai.SelectedIndex = 0;

            String[] lstLoaiBia = { "Bìa cứng", "Bìa mềm" };
            cbbLoaiBia.ItemsSource = lstLoaiBia;
            cbbLoaiBia.SelectedIndex = 0;

            var lstLoaiSach = await ctl_ls.GetList();
            cbbDanhMucSP.ItemsSource = lstLoaiSach;
            cbbDanhMucSP.SelectedValuePath = "MALS";
            cbbDanhMucSP.DisplayMemberPath = "TENLS";
            cbbDanhMucSP.SelectedIndex = 0;


            var lstNXB = await ctl_nxb.GetList();
            cbbNhaXuatBan.ItemsSource = lstNXB;
            cbbNhaXuatBan.SelectedValuePath = "MANXB";
            cbbNhaXuatBan.DisplayMemberPath = "TENNXB";
            cbbNhaXuatBan.SelectedIndex = 0;

            

            var lstSach = await ctl.GetList();
            dgvSanPham.ItemsSource = lstSach;
        }


        //private CloudBlobContainer GetCloudBlobs(string storageConnectionString, string blockClientString)
        //{

        //    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

        //    // connect to container
        //    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        //    CloudBlobContainer container = blobClient.GetContainerReference(blockClientString);
        //    if (container.CreateIfNotExists())
        //    {
        //        var permissions = container.GetPermissions();
        //        permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
        //        container.SetPermissions(permissions);
        //    }
        //    return container;
        //}

        //private string addImageToProduct(string containerName)
        //{
        //    string imageURL = "", imageFileName = "", cloudProdutURL = "";
        //    CloudBlobContainer cbc = GetCloudBlobs(Properties.Settings.Default.cloudStorageString, containerName);

        //    var dialog = new OpenFileDialog();
        //    dialog.Title = "Open Image";
        //    dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

        //    if (dialog.ShowDialog() == true)
        //    {
        //        //Create stream file from local image url
        //        imageURL = dialog.FileName.ToString();
        //        imageFileName = imageURL.Substring(imageURL.LastIndexOf('\\') + 1);
        //        // get block reference to put image on
        //        CloudBlockBlob blockBlob = cbc.GetBlockBlobReference(imageFileName);
        //        blockBlob.Properties.ContentType = "image/jpg";
        //        cloudProdutURL = blockBlob.Uri.AbsoluteUri;
        //        using (var fileStream = File.OpenRead(imageURL))
        //        {
        //            blockBlob.UploadFromFile(imageURL);
        //        }
        //    }
        //    return cloudProdutURL;
        //}


        private async void AddImageToProductAsync()
        {
            string imageURL = String.Empty;
            string path = String.Empty;
            var dialog = new OpenFileDialog();

            dialog.Title = "Open Image";
            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (dialog.ShowDialog() == true)
            {
                path = dialog.FileName;
            }

            if (!string.IsNullOrEmpty(path))
            {
                imageURL = await ctl.addProductImage(path);
                txtImageURL.Text = imageURL;
            }
        }


        private bool validateFields()
        {
            if (!ctl.validateTextBox(txtTenSP.Text))
            {
                MessageBox.Show("Tên sản phẩm không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(txtGiaNhap.Text))
            {
                MessageBox.Show("Giá nhập không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(txtGiaBan.Text))
            {
                MessageBox.Show("Giá bán không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(txtTacGia.Text))
            {
                MessageBox.Show("Tên tác giả không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(txtSoTrang.Text))
            {
                MessageBox.Show("Số trang không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(dpNgayXuatBan.Text))
            {
                MessageBox.Show("Ngày xuất bản không được trống!!!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (!ctl.validateTextBox(txtImageURL.Text))
            {
                MessageBox.Show("Link sản phẩm không được trống!!!", "Thông báo", MessageBoxButton.OK);
                return false;
            }


            return true;
        }

        private void clearText()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtGiaBan.Clear();
            txtGiaNhap.Clear();
            txtSoTrang.Clear();
            txtTacGia.Clear();
            txtKichThuoc.Clear();
            txtImageURL.Clear();
            txtMaSP.Focus();
            dpNgayXuatBan.Text = string.Empty;
        }

        private void disableText()
        {
            txtTenSP.IsEnabled = false;
            txtGiaBan.IsEnabled = false;
            txtGiaNhap.IsEnabled = false;
            txtSoTrang.IsEnabled = false;
            txtTacGia.IsEnabled = false;
            txtKichThuoc.IsEnabled = false;
            txtImageURL.IsEnabled = false;
            dpNgayXuatBan.IsEnabled = false;
            
        }

        private void enableText()
        {
            txtTenSP.IsEnabled = true;
            txtGiaBan.IsEnabled = true;
            txtGiaNhap.IsEnabled = true;
            txtSoTrang.IsEnabled = true;
            txtTacGia.IsEnabled = true;
            txtKichThuoc.IsEnabled = true;
            dpNgayXuatBan.IsEnabled = true;
        }

      

        private async void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            if(btnTimKiem.Content.Equals("Tìm Kiếm"))
            {
                btnTimKiem.Content = "Huỷ Tìm";
                var lstSach = await ctl.GetList();
                dgvSanPham.ItemsSource = lstSach.Where(t => t.MASACH.ToLower().Contains(txtTimKiem.Text.ToLower()) || t.MANXB.ToLower().Contains(txtTimKiem.Text.ToLower()) || t.TENSACH.ToLower().Contains(txtTimKiem.Text.ToLower()) || t.THELOAI.ToLower().Contains(txtTimKiem.Text.ToLower())).ToList();
                return;
            }
            
            if(btnTimKiem.Content.ToString().Equals("Huỷ Tìm"))
            {
                btnTimKiem.Content = "Tìm Kiếm";
                txtTimKiem.Clear();
                dgvSanPham.ItemsSource = await ctl.GetList();
            }
            
        }

        private void btnThemSanPham_Click(object sender, RoutedEventArgs e)
        {
            enableText();
            btnSua.Visibility = Visibility.Collapsed;
            btnXoa.Visibility = Visibility.Collapsed;
            btnLuu.Visibility = Visibility.Visible;
            btnHuy.Visibility = Visibility.Visible;
            btnThemSanPham.Visibility = Visibility.Collapsed;
            dgvSanPham.IsEnabled = false;
            clearText();
            Guid maSP = Guid.NewGuid();
            txtMaSP.Text = maSP.ToString();
        }

        private async void btnSua_Click(object sender, RoutedEventArgs e)
        {
            if(dgvSanPham.SelectedItem != null)
            {
                if (validateFields())
                {
                    SACH_DTO sach_dto = await ctl.GetAsync(txtMaSP.Text);
                    sach_dto.MANXB = cbbNhaXuatBan.SelectedValue.ToString();
                    sach_dto.TENSACH = txtTenSP.Text;
                    sach_dto.TACGIA = txtTacGia.Text;
                    sach_dto.THELOAI = cbbDanhMucSP.SelectedValue.ToString();
                    sach_dto.GIABANSACH = Convert.ToDouble(txtGiaBan.Text);
                    sach_dto.GIANHAPSACH = 50000;
                    sach_dto.SLTON = 10;
                    sach_dto.IMG = txtImageURL.Text;
                    sach_dto.LOAIBIA = cbbLoaiBia.SelectedValue.ToString();
                    sach_dto.KICHTHUOC = txtKichThuoc.Text;
                    sach_dto.NGAYXUATBAN = dpNgayXuatBan.SelectedDate;
                    sach_dto.SOTRANG = int.Parse(txtSoTrang.Text);
                    sach_dto.TRANGTHAI = cbbTrangThai.SelectedValue.ToString();
                    try
                    {
                        ctl.UpdateAsync(sach_dto);
                        MessageBox.Show("Cập nhật sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                        dgvSanPham.SelectedIndex = 1;
                        clearText();
                        disableText();
                        Load();
                    }
                    catch
                    {
                        MessageBox.Show("Cập nhật sản phẩm thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!");
            }

        }

        private void btnLuu_Click(object sender, RoutedEventArgs e)
        {
            if (validateFields())
            {
                SACH_DTO sach_dto = new SACH_DTO();
                sach_dto.MASACH = txtMaSP.Text;
                sach_dto.MANXB = cbbNhaXuatBan.SelectedValue.ToString();
                sach_dto.TENSACH = txtTenSP.Text;
                sach_dto.TACGIA = txtTacGia.Text;
                sach_dto.THELOAI = cbbDanhMucSP.SelectedValue.ToString();
                sach_dto.GIABANSACH = Convert.ToDouble(txtGiaBan.Text);
                sach_dto.GIANHAPSACH = Convert.ToDouble(txtGiaNhap.Text);
                sach_dto.SLTON = 10;
                sach_dto.IMG = txtImageURL.Text;
                sach_dto.LOAIBIA = cbbLoaiBia.SelectedValue.ToString();
                sach_dto.KICHTHUOC = txtKichThuoc.Text;
                sach_dto.NGAYXUATBAN = dpNgayXuatBan.SelectedDate;
                sach_dto.SOTRANG = int.Parse(txtSoTrang.Text);
                sach_dto.TRANGTHAI = cbbTrangThai.SelectedValue.ToString();
                try
                {
                    ctl.AddAsync(sach_dto);
                    MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    clearText();
                    disableText();
                    Load();
                }
                catch
                {
                    MessageBox.Show("Thêm sản phẩm thất bại", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    disableText();
                }


                btnHuy.Visibility = Visibility.Collapsed;
                btnThemSanPham.Visibility = Visibility.Visible;
                btnLuu.Visibility = Visibility.Collapsed;
                dgvSanPham.IsEnabled = true;
            }
        }

        private void btnHuy_Click(object sender, RoutedEventArgs e)
        {
            clearText();
            disableText();
            btnLuu.Visibility = Visibility.Collapsed;
            btnHuy.Visibility = Visibility.Collapsed;
            btnThemSanPham.Visibility = Visibility.Visible;
            dgvSanPham.IsEnabled = true;
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {   
            if(dgvSanPham.SelectedItem != null) {
                SACH_DTO s = (SACH_DTO)dgvSanPham.SelectedItem;
                MessageBoxResult result = MessageBox.Show("Bạn có muốn xoá sách " + s.TENSACH + "?", "Thông báo", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _ = ctl.DeleteAsync(txtMaSP.Text);
                        MessageBox.Show("Xoá sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                        clearText();
                        Load();
                    }
                    catch
                    {
                        MessageBox.Show("Fail to delte");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }            
        }

        //private bool checkNull(SACH_DTO s)
        //{

        //    return true;
        //}

        private void dgvSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            enableText();
            btnSua.Visibility = Visibility.Visible;
            btnXoa.Visibility = Visibility.Visible;
            SACH_DTO row = (SACH_DTO)dgvSanPham.SelectedItem;
            if(row != null)
            {
                txtTenSP.Text = row.TENSACH;
                txtMaSP.Text = row.MASACH;
                txtGiaBan.Text = row.GIABANSACH.ToString();
                txtGiaNhap.Text = row.GIANHAPSACH.ToString();
                txtImageURL.Text = row.IMG;
                txtKichThuoc.Text = row.KICHTHUOC;
                txtSoTrang.Text = row.SOTRANG.ToString();
                txtTacGia.Text = row.TACGIA;
                dpNgayXuatBan.SelectedDate = Convert.ToDateTime(row.NGAYXUATBAN);
                cbbDanhMucSP.SelectedValue = row.THELOAI.ToString();
                cbbLoaiBia.SelectedValue = row.LOAIBIA.ToString();
                cbbNhaXuatBan.SelectedValue = row.MANXB.ToString();
                //cbbTrangThai.SelectedValue = row.TRANGTHAI.ToString();
            }
            else
            {
                clearText();
            }

        }


        private void withoutNumberValidate(object sender, TextCompositionEventArgs e)
        {
            if (IsTextAllowed(e.Text))
            {
                e.Handled = true;
            }
        }

        private static readonly Regex _regex = new Regex("[0-9]"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        private void btnViewIMG_Click(object sender, RoutedEventArgs e)
        {
            if (ctl.validateTextBox(txtImageURL.Text))
            {
                ImgWindow modalWindow = new ImgWindow();
                modalWindow.getIMG(txtImageURL.Text);
                modalWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Link ảnh trống", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            AddImageToProductAsync();
        }
    }



}
