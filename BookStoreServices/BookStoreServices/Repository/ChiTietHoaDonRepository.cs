using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class ChiTietHoaDonRepository : IRepository<CHITIETHOADON>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(CHITIETHOADON item)
        {
            db.CHITIETHOADONs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void DeleteCTHDs(string maHD)
        {
            db.CHITIETHOADONs.DeleteAllOnSubmit(db.CHITIETHOADONs.Where(t => t.MAHD.Equals(maHD)).ToList());
            db.SubmitChanges();
        }

        public void DeleteCTHD(string maHD, string maSP)
        {
            db.CHITIETHOADONs.DeleteOnSubmit(db.CHITIETHOADONs.Where(t => t.MAHD.Equals(maHD)).Where(t => t.MASP.Equals(maSP)).FirstOrDefault());
            db.SubmitChanges();
        }

        public List<CHITIETHOADON> GetCTHDs(string ma)
        {
            return db.CHITIETHOADONs.Where(t => t.MAHD.Equals(ma)).ToList();
        }

        public CHITIETHOADON GetCTHD(string maHD, string maSP)
        {
            return db.CHITIETHOADONs.Where(t => t.MAHD.Equals(maHD)).Where(t => t.MASP.Equals(maSP)).FirstOrDefault();
        }

        public List<CHITIETHOADON> List()
        {
            return db.CHITIETHOADONs.ToList();
        }

        public void UpdateCTHD(CHITIETHOADON item, string maHD, string maSP)
        {
            CHITIETHOADON cthd = db.CHITIETHOADONs.Where(t => t.MAHD.Equals(maHD)).Where(t => t.MASP.Equals(maSP)).FirstOrDefault();
            cthd.MAHD = item.MAHD;
            cthd.MASP = item.MASP;
            cthd.SOLUONGMUA = item.SOLUONGMUA;
            cthd.DONGIABAN = item.DONGIABAN;
            cthd.TONGTIEN = item.TONGTIEN;
            db.SubmitChanges();
        }

        public CT_HOADON_DTO convertToDTO(CHITIETHOADON cthd)
        {
            CT_HOADON_DTO cthd_dto = new CT_HOADON_DTO();
            cthd_dto.MAHD = cthd.MAHD;
            cthd_dto.MASP = cthd.MASP;
            cthd_dto.SOLUONGMUA = cthd.SOLUONGMUA;
            cthd_dto.DONGIABAN = cthd.DONGIABAN;
            cthd_dto.TONGTIEN = cthd.TONGTIEN;
            return cthd_dto;
        }

        public CHITIETHOADON Get(string ma)
        {
            throw new NotImplementedException();
        }

        public void Delete(string ma)
        {
            throw new NotImplementedException();
        }

        public void Update(CHITIETHOADON item, string ma)
        {
            throw new NotImplementedException();
        }
    }
}