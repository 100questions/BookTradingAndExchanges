using DAL_BLL_Tier;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Configuration;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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
        public UserControlProduct()
        {

            InitializeComponent();
            Load();
        }

        public async void Load()
        {
            var lstSach = await ctl.GetList();
            dgvSanPham.ItemsSource = lstSach;
        }





        private void lsvSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SACH_DTO str = (SACH_DTO)dgvSanPham.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private CloudBlobContainer GetCloudBlobs(string storageConnectionString, string blockClientString)
        {

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);

            // connect to container
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(blockClientString);
            if (container.CreateIfNotExists())
            {
                var permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(permissions);
            }
            return container;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SACH_DTO sach_dto = new SACH_DTO();
            sach_dto.MASACH = txtMaSP.Text;
            sach_dto.MANXB = "";
            sach_dto.TENSACH = txtTenSP.Text;
            sach_dto.TACGIA = "";
            sach_dto.THELOAI = "";
            sach_dto.GIABANSACH = Convert.ToDouble(txtGiBan.Text);
            sach_dto.GIABANSACH = 50000;
            sach_dto.SLTON = 10;
            //sach_dto.IMG = addImageToProduct("product-images");
            try
            {
                _ = ctl.AddBookAsync(sach_dto);
                MessageBox.Show("Inserting product successful");
            }
            catch {
                MessageBox.Show("Inserting product fail");
            }
            Load();
        }

        private string addImageToProduct(string containerName)
        {
            string imageURL = "", imageFileName = "", cloudProdutURL = "";
            CloudBlobContainer cbc = GetCloudBlobs(Properties.Settings.Default.cloudStorageString, containerName);

            var dialog = new OpenFileDialog();
            dialog.Title = "Open Image";
            dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

            if (dialog.ShowDialog() == true)
            {
                //Create stream file from local image url
                imageURL = dialog.FileName.ToString();
                imageFileName = imageURL.Substring(imageURL.LastIndexOf('\\') + 1);
                // get block reference to put image on
                CloudBlockBlob blockBlob = cbc.GetBlockBlobReference(imageFileName);
                blockBlob.Properties.ContentType = "image/jpg";
                cloudProdutURL = blockBlob.Uri.AbsoluteUri;
                using (var fileStream = File.OpenRead(imageURL))
                {
                    blockBlob.UploadFromFile(imageURL);
                }
            }
            return cloudProdutURL;
        }

        private async void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            var lstSach = await ctl.GetBookAsync(txtMaSP.Text);
            //dgvSanPham.ItemsSource = lstSach;
        }
    }

}
