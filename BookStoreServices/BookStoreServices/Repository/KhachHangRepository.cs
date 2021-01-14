using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class KhachHangRepository : IRepository<KHACHHANG>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(KHACHHANG kh)
        {
            db.KHACHHANGs.InsertOnSubmit(kh);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.KHACHHANGs.DeleteOnSubmit(db.KHACHHANGs.Where(t => t.MAKH.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public KHACHHANG Get(string ma)
        {
            return db.KHACHHANGs.Where(t => t.MAKH.Equals(ma)).FirstOrDefault();
        }

        public KHACHHANG GetUser(string tk, string mk)
        {
            return db.KHACHHANGs.Where(t => t.SODT.Equals(tk) && t.MatKhauDN.Equals(mk)).FirstOrDefault();
        }

        public List<KHACHHANG> List()
        {
            return db.KHACHHANGs.ToList();
        }

        public void Update(KHACHHANG item, string ma)
        {
            KHACHHANG kh = db.KHACHHANGs.Where(t => t.MAKH.Equals(ma)).FirstOrDefault();
            kh.TENKH = item.TENKH;
            kh.SODT = item.SODT;
            kh.DIACHI = item.DIACHI;
            kh.MatKhauDN = item.MatKhauDN;
            kh.GIOITINH = item.GIOITINH;
            db.SubmitChanges();
        }

        public KHACHHANG_DTO convertToDTO(KHACHHANG kh)
        {
            KHACHHANG_DTO kh_dto = new KHACHHANG_DTO();
            kh_dto.MAKH = kh.MAKH;
            kh_dto.TENKH = kh.TENKH;
            kh_dto.SODT = kh.SODT;
            kh_dto.DIACHI = kh.DIACHI;
            kh_dto.GIOITINH = kh.GIOITINH;
            kh_dto.MATKHAUDN = kh.MatKhauDN;
            return kh_dto;
        }

        public KHACHHANG convertBackFromDTO(KHACHHANG_DTO kh_dto)
        {
            KHACHHANG kh = new KHACHHANG();
            kh.MAKH = kh_dto.MAKH;
            kh.TENKH = kh_dto.TENKH;
            kh.SODT = kh_dto.SODT;
            kh.DIACHI = kh_dto.DIACHI;
            kh.GIOITINH = kh_dto.GIOITINH;
            kh.MatKhauDN = kh_dto.MATKHAUDN;
            return kh;
        }
    }
}