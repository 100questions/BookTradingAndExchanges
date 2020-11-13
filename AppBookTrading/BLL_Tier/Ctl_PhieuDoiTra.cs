using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_PhieuDoiTra
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_PhieuDoiTra()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44365/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<PHIEUDOITRASACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/PhieuDoiTra", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var pdt_dto = JsonConvert.DeserializeObject<List<PHIEUDOITRASACH_DTO>>(json);
            return pdt_dto;
        }

        public async void AddAsync(PHIEUNHAPSACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/PhieuDoiTra", httpContent);
        }
    }
}
