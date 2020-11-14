using DAL_BLL_Tier;
using DAL_BLL_Tier.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
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
            _client.BaseAddress = new Uri(Contants.URL);
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<KHACHHANG_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/KhachHang", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var khachhang_dto = JsonConvert.DeserializeObject<List<KHACHHANG_DTO>>(json);
            return khachhang_dto;
        }

        public async void AddAsync(KHACHHANG_DTO kh_dto)
        {
            var json = JsonConvert.SerializeObject(kh_dto, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/KhachHang", httpContent);
        }

        public async Task<KHACHHANG_DTO> GetAsync(string maKH)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/KhachHang/" + maKH);
            var json = await response.Content.ReadAsStringAsync();
            var kh_dto = JsonConvert.DeserializeObject<KHACHHANG_DTO>(json);
            return kh_dto;
        }

        public async Task<KHACHHANG_DTO> UpdateAsync(KHACHHANG_DTO kh_dto)
        {
            var json = JsonConvert.SerializeObject(kh_dto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/KhachHang/{kh_dto.MAKH}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            kh_dto = JsonConvert.DeserializeObject<KHACHHANG_DTO>(json);
            return kh_dto;
        }
        public async Task<HttpStatusCode> DeleteAsync(string maKH)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/KhachHang/{maKH}");
            return response.StatusCode;
        }
    }
}
