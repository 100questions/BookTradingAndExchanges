using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.DTO
{
    public class QL_NGUOIDUNG_DTO
    {
        public string MANV { get; set; }
        public string MATKHAU { get; set; }
        public string TENDANGNHAP { get; set; }
        public bool? HOATDONG { get; set; }
        public int? QUYEN { get; set; }
    }
}