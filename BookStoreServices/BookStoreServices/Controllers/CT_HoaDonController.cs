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
    public class CT_HoaDonController : ApiController
    {
        private ChiTietHoaDonRepository _repository = new ChiTietHoaDonRepository();
        [HttpGet]
        [Route("api/ChiTietHoaDon")]
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
        [Route("api/ChiTietHoaDon/{maHD}")]
        public HttpResponseMessage Get(string maHD)
        {

            List<CT_HOADON_DTO> items_dto = _repository.GetCTHDs(maHD).Select(t => _repository.convertToDTO(t)).ToList();
            if (items_dto != null)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, items_dto);
            }
            else
            {
                return Request.CreateErrorResponse(System.Net.HttpStatusCode.NotFound, "Không có dữ liệu");
            }
        }

        [HttpGet]
        [Route("api/ChiTietHoaDon/{maHD}/{maSP}")]
        public HttpResponseMessage Get(string maHD, string maSP)
        {
                CT_HOADON_DTO item_dto = _repository.convertToDTO(_repository.GetCTHD(maHD, maSP));
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
        [Route("api/ChiTietHoaDon")]
        public HttpResponseMessage Post([FromBody] CHITIETHOADON item)
        {
            _repository.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "The bill' detail is posted");
        }

        [HttpPut]
        [Route("api/ChiTietHoaDon/{maHD}/{maSP}")]
        public HttpResponseMessage Put([FromBody] CHITIETHOADON item, string maHD, string maSP)
        {
            var check = _repository.GetCTHD(maHD, maSP);
            if (check != null)
            {
                _repository.UpdateCTHD(item, maHD, maSP);
                return Request.CreateResponse(HttpStatusCode.OK, "The bill' detail is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The bill' detail is not existed");
            }
        }

        [HttpDelete]
        [Route("api/ChiTietHoaDon/{maHD}")]
        public HttpResponseMessage Delete(string maHD)
        {
            var check = _repository.GetCTHDs(maHD);
            if (check != null)
            {
                _repository.DeleteCTHDs(maHD);
                return Request.CreateResponse(HttpStatusCode.OK, "The bill' details are deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The bill' details are not existed");
            }
        }

        [HttpDelete]
        [Route("api/ChiTietHoaDon/{maHD}/{maSP}")]
        public HttpResponseMessage Delete(string maHD, string maSP)
        {
            var check = _repository.GetCTHD(maHD, maSP);
            if (check != null)
            {
                _repository.DeleteCTHD(maHD, maSP);
                return Request.CreateResponse(HttpStatusCode.OK, "The bill' detail is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The bill' detail is not existed");
            }
        }
    }
}

