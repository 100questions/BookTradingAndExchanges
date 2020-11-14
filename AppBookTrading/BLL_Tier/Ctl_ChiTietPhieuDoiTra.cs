using DAL_BLL_Tier.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_ChiTietPhieuDoiTra
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_ChiTietPhieuDoiTra()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri(Contants.URL);
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CT_PHIEUDOITRASACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChiTietPhieuDoiTraSach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var ctpdt = JsonConvert.DeserializeObject<List<CT_PHIEUDOITRASACH_DTO>>(json);
            return ctpdt;
        }


        public async void AddAsync(CT_PHIEUDOITRASACH_DTO cthd)
        {
            var json = JsonConvert.SerializeObject(cthd, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChiTietPhieuDoiTraSach", httpContent);
        }
    }
}
