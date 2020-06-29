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
    public class NhanVienRepository : IRepository<NHANVIEN_DTO>
    {
        BookStoreDataContext db = new BookStoreDataContext();

        public void Add(NHANVIEN_DTO item)
        {
            NHANVIEN s = conVertNhanVienBackFromDTO(item);
            db.NHANVIENs.InsertOnSubmit(s);
            db.SubmitChanges();
        }


        public void Delete(string manv)
        {
            db.NHANVIENs.DeleteOnSubmit(db.NHANVIENs.FirstOrDefault(t => t.MANV.Equals(manv)));
            db.SubmitChanges();
        }

        public NHANVIEN_DTO Get(string manv)
        {
            return db.NHANVIENs.Where(t => t.MANV.Equals(manv)).Select(x => conVertNhanVienToDTO(x)).FirstOrDefault();
        }


        public List<NHANVIEN_DTO> List()
        {
            return db.NHANVIENs.Select(x => conVertNhanVienToDTO(x)).ToList();
        }

        public void Update(NHANVIEN_DTO item, string manv)
        {
            NHANVIEN nv = new NHANVIEN();
            nv = db.NHANVIENs.FirstOrDefault(t => t.MANV.Equals(manv));
            nv.MACV = item.MACV;
            nv.HOTEN = item.HOTEN;
            nv.GIOITINH = item.GIOITINH;
            nv.SODIENTHOAINV = item.SODIENTHOAINV;
            nv.DIACHI = item.DIACHI;
            nv.NGAYSINH = item.NGAYSINH;
            nv.CMND = item.CMND;
            db.SubmitChanges();
        }


        public NHANVIEN_DTO conVertNhanVienToDTO(NHANVIEN x)
        {
            NHANVIEN_DTO nv = new NHANVIEN_DTO();
            nv.MANV = x.MANV;
            nv.MACV = x.MACV;
            nv.HOTEN = x.HOTEN;
            nv.GIOITINH = (bool) x.GIOITINH;
            nv.SODIENTHOAINV = x.SODIENTHOAINV;
            nv.DIACHI = x.DIACHI;
            nv.CMND = x.CMND;
            nv.NGAYSINH = Convert.ToDateTime(x.NGAYSINH);
            return nv;

        }

        public NHANVIEN conVertNhanVienBackFromDTO(NHANVIEN_DTO x)
        {
            NHANVIEN nv = new NHANVIEN();
            nv.MANV = x.MANV;
            nv.MACV = x.MACV;
            nv.HOTEN = x.HOTEN;
            nv.GIOITINH = (bool)x.GIOITINH;
            nv.SODIENTHOAINV = x.SODIENTHOAINV;
            nv.DIACHI = x.DIACHI;
            nv.CMND = x.CMND;
            nv.NGAYSINH = (DateTime)x.NGAYSINH;
            return nv;
        }

    }


}