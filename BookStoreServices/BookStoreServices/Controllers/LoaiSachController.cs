using BookStoreServices.DTO;
using BookStoreServices.IRepository;
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
    public class LoaiSachController : ApiController
    {
        private LoaiSachRepository _repository = new LoaiSachRepository();
        [HttpGet]
        [Route("api/LoaiSach")]
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if (items != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/LoaiSach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            var item = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/LoaiSach")]
        public HttpResponseMessage Post([FromBody] LOAISACH item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The type books is posted");
        }

        [HttpPut]
        [Route("api/LoaiSach/{ma}")]
        public HttpResponseMessage Put([FromBody] LOAISACH item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The type of books is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The type of books is not existed");
            }
        }

        [HttpDelete]
        [Route("api/LoaiSach/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The type of books is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The type of books is not existed");
            }
        }

    }
}