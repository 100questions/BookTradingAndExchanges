﻿using BookStoreServices.DTO;
using BookStoreServices.Models;
using BookStoreServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreServices.Controllers
{
    public class PHIEUNHAPSACHController : ApiController
    {
        private PhieuNhapSachRepository _repository = new PhieuNhapSachRepository();
        [HttpGet]
        [Route("api/PhieuNhapSach")]
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if (items != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)));
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/PhieuNhapSach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            PHIEUNHAPSACH_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/PhieuNhapSach")]
        public HttpResponseMessage Post([FromBody] PHIEUNHAPSACH item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The importing bill is posted");
        }

        [HttpPut]
        [Route("api/PhieuNhapSach/{ma}")]
        public HttpResponseMessage Put([FromBody] PHIEUNHAPSACH item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The importing bill is not existed");
            }
        }

        [HttpDelete]
        [Route("api/PhieuNhapSach/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill is not existed");
            }
        }
    }
}