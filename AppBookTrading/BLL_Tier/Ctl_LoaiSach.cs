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
    public class Ctl_LoaiSach
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_LoaiSach()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://onlinebookstoreservices.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<LOAISACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/LoaiSach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var loaisach_dto = JsonConvert.DeserializeObject<List<LOAISACH_DTO>>(json);
            return loaisach_dto;
        }


        public async void AddBookTypeAsync(LOAISACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("https://bookstoreservices.azurewebsites.net/api/Sach", httpContent);
        }

        public async Task<LOAISACH_DTO> GetBookTypeAsync(string ma)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/LoaiSach" + ma);
            var json = await response.Content.ReadAsStringAsync();
            var loaisach_dto = JsonConvert.DeserializeObject<LOAISACH_DTO>(json);
            return loaisach_dto;
        }

        public async Task<LOAISACH_DTO> UpdateProductAsync(LOAISACH_DTO loaisach)
        {
            var json = JsonConvert.SerializeObject(loaisach);
            var stringContent = new StringContent(json);
            HttpResponseMessage response = await _client.PutAsync($"api/LoaiSach/{loaisach.MALS}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            loaisach = JsonConvert.DeserializeObject<LOAISACH_DTO>(json);
            return loaisach;
        }
        public async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/LoaiSach/{id}");
            return response.StatusCode;
        }
    }
}
