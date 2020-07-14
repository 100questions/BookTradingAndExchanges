using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using BookStoreServices.DTO;
using System.Xml;

namespace BookStoreServices.Repository
{
    public class SachRepository : IRepository<SACH>
    {
        private BookStoreDataContext db = new BookStoreDataContext();
        public void Add(SACH item)
        {
            db.SACHes.InsertOnSubmit(item);
            db.SubmitChanges();

        }

        public List<SACH> List()
        {
            return db.SACHes.ToList();
        }

        public SACH Get(string maSach)
        {
            return db.SACHes.Where(t => t.MASACH.Equals(maSach)).FirstOrDefault();
        }

        public void Delete(string maSach)
        {
            db.SACHes.DeleteOnSubmit(db.SACHes.FirstOrDefault(t => t.MASACH.Equals(maSach)));
            db.SubmitChanges();
        }

        public void Update(SACH s, string maSach)
        {
            SACH sach = db.SACHes.FirstOrDefault(t => t.MASACH.Equals(maSach));
            sach.MASACH = s.MASACH;
            sach.MANXB = s.MANXB;
            sach.TENSACH = s.TENSACH;
            sach.TACGIA = s.TACGIA;
            sach.THELOAI = s.THELOAI;
            sach.GIABANSACH = s.GIABANSACH;
            sach.GIANHAPSACH = s.GIANHAPSACH;
            sach.SLTON = s.SLTON;
            sach.IMG = s.IMG;
            sach.LOAIBIA = s.LOAIBIA;
            sach.KICHTHUOC = s.KICHTHUOC;
            sach.NGAYXUATBAN = s.NGAYXUATBAN;
            sach.SOTRANG = s.SOTRANG;
            db.SubmitChanges();
        }


        public SACH_DTO convertToDTO(SACH s)
        {
            SACH_DTO s_dto = new SACH_DTO();
            s_dto.MASACH = s.MASACH;
            s_dto.MANXB = s.MANXB;
            s_dto.TENSACH = s.TENSACH;
            s_dto.TACGIA = s.TACGIA;
            s_dto.THELOAI = s.THELOAI;
            s_dto.GIABANSACH = s.GIABANSACH;
            s_dto.GIANHAPSACH = s.GIANHAPSACH;
            s_dto.SLTON = s.SLTON;
            s_dto.IMG = s.IMG;
            s_dto.LOAIBIA = s.LOAIBIA;
            s_dto.KICHTHUOC = s.KICHTHUOC;
            s_dto.NGAYXUATBAN = s.NGAYXUATBAN;
            s_dto.SOTRANG = s.SOTRANG;
            return s_dto;
        }

        public SACH convertBackFromDTO(SACH_DTO s_dto)
        {
            SACH s = new SACH();
            s.MASACH = s_dto.MASACH;
            s.MANXB = s_dto.MANXB;
            s.TENSACH = s_dto.TENSACH;
            s.TACGIA = s_dto.TACGIA;
            s.THELOAI = s_dto.THELOAI;
            s.GIABANSACH = s_dto.GIABANSACH;
            s.GIANHAPSACH = s_dto.GIANHAPSACH;
            s.SLTON = s_dto.SLTON;
            return s;
        }
    }
}