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
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CT_HOADON_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChiTietHoaDon", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var sach_dto = JsonConvert.DeserializeObject<List<CT_HOADON_DTO>>(json);
            return sach_dto;
        }


        public async void AddAsync(CT_HOADON_DTO cthd)
        {
            var json = JsonConvert.SerializeObject(cthd, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChiTietHoaDon", httpContent);
        }

    }
}
