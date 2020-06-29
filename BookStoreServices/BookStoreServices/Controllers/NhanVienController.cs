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
        public HttpResponseMessage GetNhanViens()
        {
            var nvs = _repository.List();
            if (nvs != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/NhanVien/{manv}")]
        public HttpResponseMessage GetNhanVien(string manv)
        {
            var nv = _repository.Get(manv);
            if (nv != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, nv);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpPost]
        [Route("api/NhanVien")]
        public HttpResponseMessage PostNhanVien([FromBody] NHANVIEN nv)
        {
            NHANVIEN_DTO nv_dto = _repository.conVertNhanVienToDTO(nv);
            _repository.Add(nv_dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Staff is posted");
        }

        [HttpPut]
        [Route("api/NhanVien/{manv}")]
        public HttpResponseMessage PutNhanVien([FromBody] NHANVIEN nv, string manv)
        {
            var check = _repository.Get(manv);
            if(check != null)
            {
                NHANVIEN_DTO nv_dto = _repository.conVertNhanVienToDTO(nv);
                _repository.Update(nv_dto, manv);
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Staff is not existed");
            }    
        }

        [HttpDelete]
        [Route("api/NhanVien/{manv}")]
        public HttpResponseMessage DeleteNhanVien(string manv)
        {
            var check = _repository.Get(manv);
            if(check != null)
            {
                _repository.Delete(manv);
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Staff is not existed");
            }
        }



    }
}