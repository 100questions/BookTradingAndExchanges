using BookStoreServices.DTO;
using BookStoreServices.Models;
using BookStoreServices.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BookStoreServices.Controllers
{
    public class NhanVienController : ApiController
    {
        private NhanVienRepository _repository = new NhanVienRepository();
        [HttpGet]
        [Route("api/NhanVien")]
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if (items != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/NhanVien/{ma}")]
        public HttpResponseMessage GetNhanVien(string ma)
        {
            var item = _repository.Get(ma);
            if (item != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpPost]
        [Route("api/NhanVien")]
        public HttpResponseMessage Post([FromBody] NHANVIEN item)
        {
            NHANVIEN_DTO item_dto = _repository.conVertNhanVienToDTO(item);
            _repository.Add(item_dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Staff is posted");
        }

        [HttpPut]
        [Route("api/NhanVien/{ma}")]
        public HttpResponseMessage Put([FromBody] NHANVIEN item, string ma)
        {
            var check = _repository.Get(ma);
            if(check != null)
            {
                NHANVIEN_DTO item_dto = _repository.conVertNhanVienToDTO(item);
                _repository.Update(item_dto, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Staff is not existed");
            }    
        }

        [HttpDelete]
        [Route("api/NhanVien/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if(check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is not existed");
            }
        }



    }
}