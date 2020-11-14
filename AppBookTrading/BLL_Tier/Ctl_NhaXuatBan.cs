using DAL_BLL_Tier.Utils;
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
    public class Ctl_NhaXuatBan
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_NhaXuatBan()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri(Contants.URL);
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<NHAXUATBAN_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/NhaXuatBan", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var nhaxuatban_dto = JsonConvert.DeserializeObject<List<NHAXUATBAN_DTO>>(json);
            return nhaxuatban_dto;
        }


        public async void AddPublisherAsync(NHAXUATBAN_DTO nxb)
        {
            var json = JsonConvert.SerializeObject(nxb, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/NhaXuatBan", httpContent);
        }

        public async Task<NHAXUATBAN_DTO> GetPublisherAsync(string ma)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/NhaXuatBan/"+ ma);
            var json = await response.Content.ReadAsStringAsync();
            var nhaxuatban_dto = JsonConvert.DeserializeObject<NHAXUATBAN_DTO>(json);
            return nhaxuatban_dto;
        }

        public async void UpdateAsync(NHAXUATBAN_DTO nxb)
        {
            var json = JsonConvert.SerializeObject(nxb);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/NhaXuatBan/{nxb.MANXB}", stringContent);
            response.EnsureSuccessStatusCode();
        }

    }
}
