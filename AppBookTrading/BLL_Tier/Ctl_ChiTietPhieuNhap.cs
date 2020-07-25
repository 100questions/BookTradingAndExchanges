using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_ChiTietPhieuNhap
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_ChiTietPhieuNhap()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CT_PHIEUNHAPSACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChiTietPhieuNhapSach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var ctpn = JsonConvert.DeserializeObject<List<CT_PHIEUNHAPSACH_DTO>>(json);
            return ctpn;
        }


        public async void AddAsync(Ctl_ChiTietPhieuNhap ctpn)
        {
            var json = JsonConvert.SerializeObject(ctpn, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChiTietPhieuNhapSach", httpContent);
        }
    }
}
