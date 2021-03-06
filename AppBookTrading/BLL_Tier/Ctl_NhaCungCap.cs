﻿using DAL_BLL_Tier.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAL_BLL_Tier
{
    public class Ctl_NhaCungCap
    {
        public static HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_NhaCungCap()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri(Contants.URL);
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<NHACUNGCAP_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/NhaCungCap", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var ncc_dto = JsonConvert.DeserializeObject<List<NHACUNGCAP_DTO>>(json);
            return ncc_dto;
        }

        private async Task<object> NewMethod()
        {
            var json = await _reponse.Content.ReadAsStringAsync();
            var ncc_dto = JsonConvert.DeserializeObject<List<NHACUNGCAP_DTO>>(json);
            return ncc_dto;
        }

        public async void AddAsync(NHACUNGCAP_DTO ncc_dto)
        {
            var json = JsonConvert.SerializeObject(ncc_dto);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/NhaCungCap", httpContent);
        }

        public async Task<NHACUNGCAP_DTO> GetAsync(string maNCC)
        {
            HttpResponseMessage response = await _client.GetAsync($"api/NhaCungCap/" + maNCC);
            var json = await response.Content.ReadAsStringAsync();
            var ncc_dto = JsonConvert.DeserializeObject<NHACUNGCAP_DTO>(json);
            return ncc_dto;
        }

        public async void UpdateAsync(NHACUNGCAP_DTO ncc_dto)
        {
            var json = JsonConvert.SerializeObject(ncc_dto);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PutAsync($"api/NhaCungCap/{ncc_dto.MANCC}", stringContent);
            response.EnsureSuccessStatusCode();
        }
        public async Task<HttpStatusCode> DeleteAsync(string maNCC)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/NhaCungCap/{maNCC}");
            return response.StatusCode;
        }
    }
}
