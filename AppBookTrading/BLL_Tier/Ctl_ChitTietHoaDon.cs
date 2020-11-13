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
    public class Ctl_ChitTietHoaDon
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_ChitTietHoaDon()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44365/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CT_HOADON_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChiTietHoaDon", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var hds = JsonConvert.DeserializeObject<List<CT_HOADON_DTO>>(json);
            return hds;
        }

        public async Task<List<CT_HOADON_DTO>> Get(string maHD)
        {
            _reponse = await _client.GetAsync($"api/ChiTietHoaDon/"+maHD, HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var hds = JsonConvert.DeserializeObject<List<CT_HOADON_DTO>>(json);
            return hds;
        }


        public async void AddAsync(CT_HOADON_DTO cthd)
        {
            var json = JsonConvert.SerializeObject(cthd, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChiTietHoaDon", httpContent);
        }

    }
}
