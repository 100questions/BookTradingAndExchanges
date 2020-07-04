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
    public class QL_NguoiDungController : ApiController
    {
        private QuanLyNguoiDungRepository _repository = new QuanLyNguoiDungRepository();
        [HttpGet]
        [Route("api/QuanLyNguoiDung")]
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
        [Route("api/QuanLyNguoiDung/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            QL_NGUOIDUNG_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/QuanLyNguoiDung")]
        public HttpResponseMessage Post([FromBody] QL_NguoiDung item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The user is posted");
        }

        [HttpPut]
        [Route("api/QuanLyNguoiDung/{ma}")]
        public HttpResponseMessage Put([FromBody] QL_NguoiDung item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The user is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The user is not existed");
            }
        }

        [HttpDelete]
        [Route("api/QuanLyNguoiDung/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Delete(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The user is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The user is not existed");
            }
        }
    }
}
