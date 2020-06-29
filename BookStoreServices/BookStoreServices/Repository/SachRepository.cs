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
    public class SachRepository : IRepository<SACH_DTO>
    {
        private BookStoreDataContext db = new BookStoreDataContext();
        public void Add(SACH_DTO item)
        {
            SACH s = conVertBookBackFromDTO(item);
            db.SACHes.InsertOnSubmit(s);
            db.SubmitChanges();

        }

        public List<SACH_DTO> List()
        {
            return db.SACHes.Select(x => conVertBookToDTO(x)).ToList();
        }

        public SACH_DTO Get(string maSach)
        {
            return db.SACHes.Where(t => t.MASACH.Equals(maSach)).Select(x => conVertBookToDTO(x)).FirstOrDefault();
        }

        public void Delete(string maSach)
        {
            db.SACHes.DeleteOnSubmit(db.SACHes.FirstOrDefault(t => t.MASACH.Equals(maSach)));
            db.SubmitChanges();
        }

        public void Update(SACH_DTO s, string maSach)
        {
            SACH sach = new SACH();
            sach = db.SACHes.FirstOrDefault(t => t.MASACH.Equals(maSach));
            sach.MASACH = s.MASACH;
            sach.MANXB = s.MANXB;
            sach.TENSACH = s.TENSACH;
            sach.TACGIA = s.TACGIA;
            sach.THELOAI = s.THELOAI;
            sach.GIABANSACH = s.GIABANSACH;
            sach.GIANHAPSACH = s.GIANHAPSACH;
            sach.SLTON = s.SLTON;
            db.SubmitChanges();
        }


        public SACH_DTO conVertBookToDTO(SACH s)
        {
            SACH_DTO sach = new SACH_DTO();
            sach.MASACH = s.MASACH;
            sach.MANXB = s.MANXB;
            sach.TENSACH = s.TENSACH;
            sach.TACGIA = s.TACGIA;
            sach.THELOAI = s.THELOAI;
            sach.GIABANSACH = s.GIABANSACH;
            sach.GIANHAPSACH = s.GIANHAPSACH;
            sach.SLTON = s.SLTON;
            return sach;
        }

        public SACH conVertBookBackFromDTO(SACH_DTO s)
        {
            SACH sach = new SACH();
            sach.MASACH = s.MASACH;
            sach.MANXB = s.MANXB;
            sach.TENSACH = s.TENSACH;
            sach.TACGIA = s.TACGIA;
            sach.THELOAI = s.THELOAI;
            sach.GIABANSACH = s.GIABANSACH;
            sach.GIANHAPSACH = s.GIANHAPSACH;
            sach.SLTON = s.SLTON;
            return sach;
        }
    }
}