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
    public class NhaXuatBanController : ApiController
    {
        private NhaXuatBanRepository _repository = new NhaXuatBanRepository();

        [HttpGet]
        [Route("api/NhaXuatBan")]
        public HttpResponseMessage Get()
        {
            var items = _repository.List();
            if (items != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)).ToList());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/NhaXuatBan/{ma}")]
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
        [Route("api/NhaXuatBan")]
        public HttpResponseMessage Post([FromBody] NHAXUATBAN item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The publisher is posted");
        }

        [HttpPut]
        [Route("api/NhaXuatBan/{ma}")]
        public HttpResponseMessage Put([FromBody] NHAXUATBAN item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The publisher is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The publisher is not existed");
            }
        }

        [HttpDelete]
        [Route("api/NhaXuatBan/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The publisher is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The publisher is not existed");
            }
        }
    }
}
