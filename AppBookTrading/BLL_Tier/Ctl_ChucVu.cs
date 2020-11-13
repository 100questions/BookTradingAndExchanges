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
    public class Ctl_ChucVu
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_ChucVu()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44365/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CHUCVU_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChucVu", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var cv = JsonConvert.DeserializeObject<List<CHUCVU_DTO>>(json);
            return cv;
        }


        public async void AddAsync(CHUCVU_DTO cv)
        {
            var json = JsonConvert.SerializeObject(cv, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChucVu", httpContent);
        }

        public async Task<CHUCVU_DTO> GetAsync(string ma)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/ChucVu/" + ma);
            var json = await response.Content.ReadAsStringAsync();
            var cv = JsonConvert.DeserializeObject<CHUCVU_DTO>(json);
            return cv;
        }

        public async Task<CHUCVU_DTO> UpdateAsync(CHUCVU_DTO cv)
        {
            var json = JsonConvert.SerializeObject(cv);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/ChucVu/{cv.MACV}", stringContent);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            json = await response.Content.ReadAsStringAsync();
            cv = JsonConvert.DeserializeObject<CHUCVU_DTO>(json);
            return cv;
        }
        public async Task<HttpStatusCode> DeleteAsync(string ma)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/ChucVu/{ma}");
            return response.StatusCode;
        }

    }
}
