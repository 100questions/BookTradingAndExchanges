﻿using BookStoreServices.Models;
using BookStoreServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreServices.Controllers
{
    public class KhachHangController : ApiController
    {
        private KhachHangRepository _repository = new KhachHangRepository();
        [HttpGet]
        [Route("api/KhachHang")]
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if (items != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)).ToList());
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/KhachHang/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            KHACHHANG_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
            if (item_dto != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, item_dto);
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpPost]
        [Route("api/KhachHang")]
        public HttpResponseMessage Post([FromBody] KHACHHANG item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The customer is posted");
        }

        [HttpPut]
        [Route("api/KhachHang/{ma}")]
        public HttpResponseMessage Put([FromBody] KHACHHANG item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The customer is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The customer is not existed");
            }
        }

        [HttpDelete]
        [Route("api/KhachHang/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The customer is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The customer is not existed");
            }
        }
    }
}