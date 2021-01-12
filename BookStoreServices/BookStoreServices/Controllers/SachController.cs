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
                return Request.CreateResponse(HttpStatusCode.OK, _repository.List().Select(x => _repository.convertToDTO(x)));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/Sach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            SACH_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/Sach/HoaDon/{maHD}")]
        public HttpResponseMessage GetSachByMaHD(string maHD)
        {
            var lstSach = _repository.GetListByMaHD(maHD);
            if (lstSach != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstSach);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpGet]
        [Route("api/Sach/ChiTiet/{maKH}")]
        public HttpResponseMessage GetSachByMaKH(string maKH)
        {
            var item_dto = _repository.GetList(maKH);
            List<SACH_DTO> lstSach = new List<SACH_DTO>();
            foreach (var item in item_dto)
            {
                lstSach.Add(_repository.convertToDTO(item));
            }
            if (item_dto != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, lstSach);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "NULL");
            }
        }

        [HttpPost]
        [Route("api/Sach")]
        public HttpResponseMessage Post([FromBody] SACH item)
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
        [Route("api/Sach/{ma}")]
        public HttpResponseMessage Put([FromBody] SACH item, string ma)
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
        [Route("api/Sach/{ma}")]
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
