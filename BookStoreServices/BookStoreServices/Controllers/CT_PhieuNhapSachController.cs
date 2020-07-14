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
            List<CT_PHIEUNHAPSACH_DTO> items_dto = _repository.GetCTPNSs(ma).Select(t => _repository.convertToDTO(t)).ToList();
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
        [Route("api/ChiTietPhieuNhapSach/{maPNS}/{maSach}")]
        public HttpResponseMessage Get(string maPNS, string maSach)
        {
            CT_PHIEUNHAPSACH_DTO item_dto = _repository.convertToDTO(_repository.GetCTPNS(maPNS, maSach));
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
            return Request.CreateResponse(HttpStatusCode.OK, "The importing bill detail is posted");
        }

        [HttpPut]
        [Route("api/ChiTietPhieuNhapSach/{maPNS}/{maSach}")]
        public HttpResponseMessage Put([FromBody] CT_PHIEUNHAPSACH item, string maPNS, string maSach)
        {
            var check = _repository.GetCTPNS(maPNS, maSach);
            if (check != null)
            {
                _repository.UpdateCTPNS(item, maPNS, maSach);
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill detail is updated");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "The importing bill detail is not existed");
            }
        }

        [HttpDelete]
        [Route("api/ChiTietPhieuNhapSach/{ma}")]
        public HttpResponseMessage Delete(string ma)
        {
            var check = _repository.GetCTPNSs(ma);
            if (check != null)
            {
                _repository.DeleteCTPNs(ma);
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill details is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill details are not existed");
            }
        }

        [HttpDelete]
        [Route("api/ChiTietPhieuNhapSach/{maPNS}/{maSach}")]
        public HttpResponseMessage Delete(string maPNS, string maSach)
        {
            var check = _repository.GetCTPNS(maPNS, maSach);
            if (check != null)
            {
                _repository.DeletePNS(maPNS, maSach);
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill detail is deleted");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, "The importing bill detail is not existed");
            }
        }
    }
}
