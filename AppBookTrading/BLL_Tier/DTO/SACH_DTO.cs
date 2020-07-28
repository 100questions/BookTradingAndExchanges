using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DAL_BLL_Tier
{
    public class SACH_DTO
    {
        public string MASACH { get; set; }
        public string MANXB { get; set; }
        public string TENSACH { get; set; }
        public string TACGIA { get; set; }
        public string THELOAI { get; set; }
        public double GIABANSACH { get; set; }
        public double GIANHAPSACH { get; set; }
        public int? SLTON { get; set; }
        public string IMG { get; set; }
        public string LOAIBIA { get; set; }
        public string KICHTHUOC { get; set; }
        public DateTime? NGAYXUATBAN { get; set; }
        public int? SOTRANG { get; set; }
        public string TRANGTHAI { get; set; }

        public static implicit operator List<object>(SACH_DTO v)
        {
            throw new NotImplementedException();
        }
    }
}