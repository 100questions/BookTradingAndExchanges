using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.DTO
{
    public class PHIEUNHAPSACH_DTO
    {
        public string MAPHIEUNHAP { get; set; }
        public string MANV { get; set; }
        public DateTime? NGAYNHAP { get; set; }
        public double THANHTIENPHIEUNHAP { get; set; }

    }
}