using DAL_BLL_Tier;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_HoaDon
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;
        public Ctl_HoaDon()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44365/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<HOADON_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/HoaDon", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var hoadon_dto = JsonConvert.DeserializeObject<List<HOADON_DTO>>(json);
            return hoadon_dto;
        }

        public async Task<HOADON_DTO> Get(String maHD)
        {
            _reponse = await _client.GetAsync($"api/HoaDon/" + maHD, HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var hoadon_dto = JsonConvert.DeserializeObject<HOADON_DTO>(json);
            return hoadon_dto;
        }

        public async void UpadateAsync(HOADON_DTO hd)
        {
            var json = JsonConvert.SerializeObject(hd);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/HoaDon/" + hd.MAHD, stringContent);
            response.EnsureSuccessStatusCode();
        }
    }
}
