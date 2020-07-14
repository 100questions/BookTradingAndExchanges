using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_PhieuNhapSach
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_PhieuNhapSach()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<PHIEUNHAPSACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"/api/PhieuNhapSach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var phieuNhapSach_dto = JsonConvert.DeserializeObject<List<PHIEUNHAPSACH_DTO>>(json);
            return phieuNhapSach_dto;
        }
    }
}
