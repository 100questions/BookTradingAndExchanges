using BookStoreServices.DTO;
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
    public class SachController : ApiController
    {
        private SachRepository _repository = new SachRepository();
        [HttpGet]
        [Route("api/Sach")]
        public HttpResponseMessage GetSachs()
        {
            var sachs = _repository.List();
            if(sachs != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _repository.List());
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/Sach/{maSach}")]
        public HttpResponseMessage GetSachs(string maSach)
        {
            SACH_DTO sach = _repository.Get(maSach);

            if (sach != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, sach);
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpPost]
        [Route("api/Sach")]
        public HttpResponseMessage PostSach([FromBody] SACH s)
        {
            SACH_DTO sach_dto = _repository.conVertBookToDTO(s);
            _repository.Add(sach_dto);
            return Request.CreateResponse(HttpStatusCode.OK, "Book is posted");
        }

        [HttpPut]
        [Route("api/Sach/{maSach}")]
        public HttpResponseMessage PutSach([FromBody] SACH s, string maSach)
        {
            var check = _repository.Get(maSach);
            if (check != null)
            {
                SACH_DTO sach_dto = _repository.conVertBookToDTO(s);
                _repository.Update(sach_dto, maSach);
                return Request.CreateResponse(HttpStatusCode.OK, "Book is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Book is not existed");
            }
        }

        [HttpDelete]
        [Route("api/Sach/{maSach}")]
        public HttpResponseMessage DeleteSach(string maSach)
        {
            var check = _repository.Get(maSach);
            if (check != null)
            {
                _repository.Delete(maSach);
                return Request.CreateResponse(HttpStatusCode.OK, "Book is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Book is not existed");
            }
        }
    }
}
