using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
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
    /// Interaction logic for UserControlProduct.xaml
    /// </summary>
    public partial class UserControlProduct : UserControl
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public UserControlProduct()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            Load();
        }

        public async void Load()
        {
            var lstSach = await GetListSach();
            dgvSanPham.ItemsSource = lstSach;

        }

        public async Task<List<SachDto>> GetListSach()
        {
            _reponse = await _client.GetAsync($"/api/Sach",HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var sachDtos = JsonConvert.DeserializeObject<List<SachDto>>(json);
            return sachDtos;
        }

        private void lsvSanPham_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SachDto str = (SachDto)dgvSanPham.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
