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
    public class HoaDonController : ApiController
    {
        private HoaDonRepository _repository = new HoaDonRepository();
        [HttpGet]
        [Route("api/HoaDon")]
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
        [Route("api/HoaDon/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            HOADON_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/HoaDon")]
        public HttpResponseMessage Post([FromBody] HOADON item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The bill is posted");
        }

        [HttpPut]
        [Route("api/HoaDon/{ma}")]
        public HttpResponseMessage Put([FromBody] HOADON item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The bill is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The bill is not existed");
            }
        }

        [HttpDelete]
        [Route("api/HoaDon/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The bill is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The bill is not existed");
            }
        }
    }
}