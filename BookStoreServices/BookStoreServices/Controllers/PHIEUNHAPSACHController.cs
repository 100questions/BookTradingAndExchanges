using BookStoreServices.DTO;
using BookStoreServices.Models;
using BookStoreServices.Repository;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStoreServices.Controllers
{
    public class PHIEUNHAPSACHController : ApiController
    {
        private PhieuNhapSachRepository _repository = new PhieuNhapSachRepository();
        [HttpGet]
        [Route("api/PhieuNhapSach")]
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
        [Route("api/PhieuNhapSach/{ma}")]
        public HttpResponseMessage Get(string ma)
        {
            PHIEUNHAPSACH_DTO item_dto = _repository.convertToDTO(_repository.Get(ma));
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
        [Route("api/PhieuNhapSach")]
        public HttpResponseMessage Post([FromBody] PHIEUNHAPSACH item)
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
        [Route("api/PhieuNhapSach/{ma}")]
        public HttpResponseMessage Put([FromBody] PHIEUNHAPSACH item, string ma)
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
        [Route("api/PhieuNhapSach/{ma}")]
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
