using DAL_BLL_Tier.Utils;
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
    public class Ctl_NguoiDung
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_NguoiDung()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri(Contants.URL);
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<NGUOIDUNG_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/QuanLyNguoiDung", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var nd_dto = JsonConvert.DeserializeObject<List<NGUOIDUNG_DTO>>(json);
            return nd_dto;
        }


        public async void AddAsync(NGUOIDUNG_DTO nv_dto)
        {
            var json = JsonConvert.SerializeObject(nv_dto, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/QuanLyNguoiDung", httpContent);
        }

        public async Task<NGUOIDUNG_DTO> GetAsync(string ma)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/QuanLyNguoiDung/" + ma);
            var json = await response.Content.ReadAsStringAsync();
            var nd_dto = JsonConvert.DeserializeObject<NGUOIDUNG_DTO>(json);
            return nd_dto;
        }

        public async Task<NGUOIDUNG_DTO> GetUerAsync(string userName, string passWord)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/QuanLyNguoiDung/" + userName + "/" + passWord);
            var json = await response.Content.ReadAsStringAsync();
            var nd_dto = JsonConvert.DeserializeObject<NGUOIDUNG_DTO>(json);
            return nd_dto;
        }

        public async Task<NGUOIDUNG_DTO> UpdateAsync(NGUOIDUNG_DTO nd_dto)
        {
            var json = JsonConvert.SerializeObject(nd_dto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/QuanLyNguoiDung/{nd_dto.MANV}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            nd_dto = JsonConvert.DeserializeObject<NGUOIDUNG_DTO>(json);
            return nd_dto;
        }
        public async Task<HttpStatusCode> DeleteAsync(string ma)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/QuanLyNguoiDung/{ma}");
            return response.StatusCode;
        }
    }
}
