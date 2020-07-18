using BookStoreServices.DTO;
using BookStoreServices.Models;
using BookStoreServices.Repository;
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
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/ChiTietHoaDon/{maHD}")]
        public HttpResponseMessage Get(string maHD)
        {

            List<CT_HOADON_DTO> items_dto = _repository.GetCTHDs(maHD).Select(t => _repository.convertToDTO(t)).ToList();
            if (items_dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, items_dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/ChiTietHoaDon/{maHD}/{maSP}")]
        public HttpResponseMessage Get(string maHD, string maSP)
        {
                CT_HOADON_DTO item_dto = _repository.convertToDTO(_repository.GetCTHD(maHD, maSP));
                if (item_dto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, item_dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
                }
        }

        [HttpPost]
        [Route("api/ChiTietHoaDon")]
        public HttpResponseMessage Post([FromBody] CHITIETHOADON item)
        {
            try
            {
                _repository.Add(item);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpPut]
        [Route("api/ChiTietHoaDon/{maHD}/{maSP}")]
        public HttpResponseMessage Put([FromBody] CHITIETHOADON item, string maHD, string maSP)
        {
            var check = _repository.GetCTHD(maHD, maSP);
            if (check != null)
            {
                _repository.UpdateCTHD(item, maHD, maSP);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
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
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NULL");
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
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NULL");
            }
        }
    }
}

