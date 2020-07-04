using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class QuanLyNguoiDungRepository : IRepository<QL_NguoiDung>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(QL_NguoiDung item)
        {
            db.QL_NguoiDungs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.QL_NguoiDungs.DeleteOnSubmit(db.QL_NguoiDungs.Where(t => t.MANV.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public QL_NguoiDung Get(string ma)
        {
            return db.QL_NguoiDungs.Where(t => t.MANV.Equals(ma)).FirstOrDefault();
        }

        public List<QL_NguoiDung> List()
        {
            return db.QL_NguoiDungs.ToList();
        }

        public void Update(QL_NguoiDung item, string ma)
        {
            QL_NguoiDung ql = db.QL_NguoiDungs.Where(t => t.MANV.Equals(ma)).FirstOrDefault();
            ql.MANV = item.MANV;
            ql.TenDangNhap = item.TenDangNhap;
            ql.MatKhau = item.MatKhau;
            ql.HoatDong = item.HoatDong;
            ql.Quyen = item.Quyen;
            db.SubmitChanges();
        }

        public QL_NGUOIDUNG_DTO convertToDTO(QL_NguoiDung qlnd)
        {
            QL_NGUOIDUNG_DTO qlnd_dto = new QL_NGUOIDUNG_DTO();
            qlnd_dto.MANV = qlnd.MANV;
            qlnd_dto.TENDANGNHAP = qlnd.TenDangNhap;
            qlnd_dto.MATKHAU = qlnd.MatKhau;
            qlnd_dto.HOATDONG = qlnd.HoatDong;
            qlnd_dto.QUYEN = qlnd.Quyen;
            return qlnd_dto;
        }

        public QL_NguoiDung convertBackFromDTO(QL_NGUOIDUNG_DTO qlnd_dto)
        {
            QL_NguoiDung qlnd = new QL_NguoiDung();
            qlnd.MANV = qlnd_dto.MANV;
            qlnd.TenDangNhap = qlnd_dto.TENDANGNHAP;
            qlnd.MatKhau = qlnd_dto.MATKHAU;
            qlnd.HoatDong = qlnd_dto.HOATDONG;
            qlnd.Quyen = qlnd_dto.QUYEN;
            return qlnd;
        }
    }
}