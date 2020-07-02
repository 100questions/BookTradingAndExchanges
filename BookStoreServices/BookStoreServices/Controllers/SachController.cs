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
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if(items != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, _repository.List());
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/Sach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            SACH_DTO item_dto = _repository.Get(ma);

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
        [Route("api/Sach")]
        public HttpResponseMessage Post([FromBody] SACH item)
        {
            SACH_DTO item_dto = _repository.convertToDTO(item);
            _repository.Add(item_dto);
            return Request.CreateResponse(HttpStatusCode.OK, "The book is posted");
        }

        [HttpPut]
        [Route("api/Sach/{ma}")]
        public HttpResponseMessage Put([FromBody] SACH item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                SACH_DTO item_dto = _repository.convertToDTO(item);
                _repository.Update(item_dto, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The book is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The book is not existed");
            }
        }

        [HttpDelete]
        [Route("api/Sach/{ma}")]
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
