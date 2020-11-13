using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Firebase.Storage;
using System.IO;

namespace DAL_BLL_Tier
{
    public class Ctl_Sach
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;



        public Ctl_Sach()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:44365/");
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }

        public async Task<string> addProductImage(string path)
        {

            // Get any Stream - it can be FileStream, MemoryStream or any other type of Stream
            var stream = File.Open(path, FileMode.Open);

            // Constructr FirebaseStorage, path to where you want to upload the file and Put it there

            var task = new FirebaseStorage("book-store-service.appspot.com")
                .Child("product-images")
                .Child(Path.GetFileName(path))
                .PutAsync(stream);

            

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            return downloadUrl;
        }


        public async Task<List<SACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/Sach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var sach_dto = JsonConvert.DeserializeObject<List<SACH_DTO>>(json);
            return sach_dto;
        }


        public async void AddAsync(SACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/Sach", httpContent);
        }

        public async Task<SACH_DTO> GetAsync(string maSP)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/Sach/" + maSP);
            var json = await response.Content.ReadAsStringAsync();
            var sach_dto = JsonConvert.DeserializeObject<SACH_DTO>(json);
            return sach_dto;
        }

        public async void UpdateAsync(SACH_DTO sach)
        {
            var json = JsonConvert.SerializeObject(sach);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/Sach/{sach.MASACH}", stringContent);
            response.EnsureSuccessStatusCode();
        }
        public async Task<HttpStatusCode> DeleteAsync(string maSP)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/Sach/{maSP}");
            return response.StatusCode;
        }


        public bool validateTextBox(string text)
        {
            if (!string.IsNullOrEmpty(text))
                return true;
            return false;

        }







    }
}
