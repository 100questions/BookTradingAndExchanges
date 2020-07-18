using DAL_BLL_Tier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_KhachHang
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_KhachHang()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<KHACHHANG_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/KhachHang", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var khachhang_dto = JsonConvert.DeserializeObject<List<KHACHHANG_DTO>>(json);
            return khachhang_dto;
        }
    }
}
