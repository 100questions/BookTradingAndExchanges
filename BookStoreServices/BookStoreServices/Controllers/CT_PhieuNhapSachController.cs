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
    public class CT_PhieuNhapSachController : ApiController
    {
        private ChiTietPhieuNhapSachRepository _repository = new ChiTietPhieuNhapSachRepository();
        [HttpGet]
        [Route("api/ChiTietPhieuNhapSach")]
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
        [Route("api/ChiTietPhieuNhapSach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            CT_PHIEUNHAPSACH_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/ChiTietPhieuNhapSach")]
        public HttpResponseMessage Post([FromBody] CT_PHIEUNHAPSACH item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The book is posted");
        }

        [HttpPut]
        [Route("api/ChiTietPhieuNhapSach/{ma}")]
        public HttpResponseMessage Put([FromBody] CT_PHIEUNHAPSACH item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The book is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The book is not existed");
            }
        }

        [HttpDelete]
        [Route("api/ChiTietPhieuNhapSach/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The book is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The book is not existed");
            }
        }
    }
}
