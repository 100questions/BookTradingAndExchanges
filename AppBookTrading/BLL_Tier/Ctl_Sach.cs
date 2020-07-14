using Azure.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DAL_BLL_Tier
{
    public class Ctl_Sach
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_Sach()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://bookstoreservices.azurewebsites.net/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
        public async Task<List<SACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"/api/Sach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var sach_dto = JsonConvert.DeserializeObject<List<SACH_DTO>>(json);
            return sach_dto;
        }

        public async Task<Uri> AddBookAsync(SACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach, Formatting.Indented);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await _client.PostAsync("/api/Sach", byteContent);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<SACH_DTO> GetBookAsync(string path)
        {
            HttpResponseMessage response = await _client.GetAsync($"/api/Sach"+path);
            var json = await response.Content.ReadAsStringAsync();
            var sach_dto = JsonConvert.DeserializeObject<SACH_DTO>(json);
            return sach_dto;
        }

        public async Task<SACH_DTO> UpdateProductAsync(SACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach);
            var stringContent = new StringContent(json);
            HttpResponseMessage response = await _client.PutAsync($"api/products/{sach.MASACH}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            sach = JsonConvert.DeserializeObject<SACH_DTO>(json);
            return sach;
        }
        public async Task<HttpStatusCode> DeleteProductAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/products/{id}");
            return response.StatusCode;
        }







    }
}
