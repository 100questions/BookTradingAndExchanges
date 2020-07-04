using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Http;

namespace BookStoreServices.Repository
{
    public class NhanVienRepository : IRepository<NHANVIEN>
    {
        BookStoreDataContext db = new BookStoreDataContext();

        public void Add(NHANVIEN item)
        {
            db.NHANVIENs.InsertOnSubmit(item);
            db.SubmitChanges();
        }


        public void Delete(string manv)
        {
            db.NHANVIENs.DeleteOnSubmit(db.NHANVIENs.FirstOrDefault(t => t.MANV.Equals(manv)));
            db.SubmitChanges();
        }

        public NHANVIEN Get(string manv)
        {
            return db.NHANVIENs.Where(t => t.MANV.Equals(manv)).FirstOrDefault();
        }


        public List<NHANVIEN> List()
        {
            return db.NHANVIENs.ToList();
        }

        public void Update(NHANVIEN item, string manv)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(t => t.MANV.Equals(manv));
            nv.MACV = item.MACV;
            nv.HOTEN = item.HOTEN;
            nv.GIOITINH = item.GIOITINH;
            nv.SODIENTHOAINV = item.SODIENTHOAINV;
            nv.DIACHI = item.DIACHI;
            nv.NGAYSINH = item.NGAYSINH;
            nv.CMND = item.CMND;
            db.SubmitChanges();
        }


        public NHANVIEN_DTO convertToDTO(NHANVIEN nv)
        {
            NHANVIEN_DTO nv_dto = new NHANVIEN_DTO();
            nv_dto.MANV = nv.MANV;
            nv_dto.MACV = nv.MACV;
            nv_dto.HOTEN = nv.HOTEN;
            nv_dto.GIOITINH = (bool)nv.GIOITINH;
            nv_dto.SODIENTHOAINV = nv.SODIENTHOAINV;
            nv_dto.DIACHI = nv.DIACHI;
            nv_dto.CMND = nv.CMND;
            nv_dto.NGAYSINH = Convert.ToDateTime(nv.NGAYSINH);
            return nv_dto;

        }

        public NHANVIEN convertBackFromDTO(NHANVIEN_DTO nv_dto)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = nv_dto.MANV;
            nv.MACV = nv_dto.MACV;
            nv.HOTEN = nv_dto.HOTEN;
            nv.GIOITINH = (bool)nv_dto.GIOITINH;
            nv.SODIENTHOAINV = nv_dto.SODIENTHOAINV;
            nv.DIACHI = nv_dto.DIACHI;
            nv.CMND = nv_dto.CMND;
            nv.NGAYSINH = (DateTime)nv_dto.NGAYSINH;
            return nv;
        }

    }


}