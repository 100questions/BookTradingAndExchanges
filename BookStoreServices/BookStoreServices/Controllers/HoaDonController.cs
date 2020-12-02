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
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)).ToList());
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/HoaDon/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            HOADON_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
            if (item_dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, item_dto);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/HoaDon/KhachHang/{maKH}")]
        public HttpResponseMessage GetHDByMaKH(string maKH)
        {
            var item_dto = _repository.GetByMaKH(maKH);
            List<HOADON_DTO> lstHD = new List<HOADON_DTO>();
            foreach (var item in item_dto)
            {
                lstHD.Add(_repository.convertToDTO(item));
            }
            if (lstHD != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstHD);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpPost]
        [Route("api/HoaDon")]
        public HttpResponseMessage Post([FromBody] HOADON item)
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
        [Route("api/HoaDon/{ma}")]
        public HttpResponseMessage Put([FromBody] HOADON item, string ma)
        {
            var check = _repository.Get(ma);
            if (check != null)
            {
                _repository.Update(item, ma);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
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
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "NULL");
            }
        }
    }
}