using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_NhanVien
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_NhanVien()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<NHANVIEN_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/NhanVien", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var nv_dto = JsonConvert.DeserializeObject<List<NHANVIEN_DTO>>(json);
            return nv_dto;
        }


        public async void AddAsync(NHANVIEN_DTO nv_dto)
        {
            var json = JsonConvert.SerializeObject(nv_dto, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/NhanVien", httpContent);
        }

        public async Task<NHANVIEN_DTO> GetAsync(string ma)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/NhanVien/" + ma);
            var json = await response.Content.ReadAsStringAsync();
            var nv_dto = JsonConvert.DeserializeObject<NHANVIEN_DTO>(json);
            return nv_dto;
        }

        public async Task<NHANVIEN_DTO> UpdateAsync(NHANVIEN_DTO nv_dto)
        {
            var json = JsonConvert.SerializeObject(nv_dto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/NhanVien/{nv_dto.MANV}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            nv_dto = JsonConvert.DeserializeObject<NHANVIEN_DTO>(json);
            return nv_dto;
        }
        public async Task<HttpStatusCode> DeleteAsync(string ma)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/NhanVien/{ma}");
            return response.StatusCode;
        }
    }
}
