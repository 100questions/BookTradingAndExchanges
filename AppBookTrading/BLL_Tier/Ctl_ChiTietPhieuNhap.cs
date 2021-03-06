﻿using DAL_BLL_Tier.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL_Tier
{
    public class Ctl_ChiTietPhieuNhap
    {
        public HttpClient _client;
        public HttpResponseMessage _reponse;

        public Ctl_ChiTietPhieuNhap()
        {

            _client = new HttpClient();
            _client.BaseAddress = new Uri(Contants.URL);
            //_client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<List<CT_PHIEUNHAPSACH_DTO>> GetList()
        {
            _reponse = await _client.GetAsync($"api/ChiTietPhieuNhapSach", HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var ctpns = JsonConvert.DeserializeObject<List<CT_PHIEUNHAPSACH_DTO>>(json);
            return ctpns;
        }

        public async Task<List<CT_PHIEUNHAPSACH_DTO>> Get(String maPN)
        {
            _reponse = await _client.GetAsync($"api/ChiTietPhieuNhapSach/" + maPN, HttpCompletionOption.ResponseHeadersRead);
            var json = await _reponse.Content.ReadAsStringAsync();
            var ctpns = JsonConvert.DeserializeObject<List<CT_PHIEUNHAPSACH_DTO>>(json);
            return ctpns;
        }


        public async void AddAsync(CT_PHIEUNHAPSACH_DTO ctpn)
        {
            var json = JsonConvert.SerializeObject(ctpn, Formatting.Indented);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync($"api/ChiTietPhieuNhapSach", httpContent);
        }
    }
}
