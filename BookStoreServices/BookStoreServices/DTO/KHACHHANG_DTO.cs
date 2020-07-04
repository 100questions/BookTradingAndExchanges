using System.Web.Mvc;

namespace BookStoreServices.Repository
{
    public class KHACHHANG_DTO
    {
        //kh_dto.MAKH = item.MAKH;
        //    kh_dto.TENKH = item.TENKH;
        //    kh_dto.SODT = item.SODT;
        //    kh_dto.DIACHI = item.DIACHI;
        //    kh_dto.GIOITINH = item.GIOITINH;
        //    kh_dto.CMND = item.CMND;

        public string MAKH { get; set; }
        public string TENKH { get; set; }
        public string SODT { get; set; }
        public string DIACHI { get; set; }
        public bool? GIOITINH { get; set; }
        public string MATKHAUDN { get; set; }

    }
}