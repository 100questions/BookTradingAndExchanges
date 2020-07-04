using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class ChiTietPhieuNhapSachRepository : IRepository<CT_PHIEUNHAPSACH>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(CT_PHIEUNHAPSACH item)
        {
            db.CT_PHIEUNHAPSACHes.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.CT_PHIEUNHAPSACHes.DeleteOnSubmit(db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public CT_PHIEUNHAPSACH Get(string ma)
        {
            return db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault();
        }

        public List<CT_PHIEUNHAPSACH> List()
        {
            return db.CT_PHIEUNHAPSACHes.ToList();
        }

        public void Update(CT_PHIEUNHAPSACH item, string ma)
        {
            CT_PHIEUNHAPSACH ctpns = db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault();
            ctpns.MAPHIEU = item.MAPHIEU;
            ctpns.MASACH = item.MASACH;
            ctpns.SLNHAP = item.SLNHAP;
            ctpns.THANHTIEN = item.THANHTIEN;
            db.SubmitChanges();
        }

        public CT_PHIEUNHAPSACH_DTO convertToDTO(CT_PHIEUNHAPSACH ctpns)
        {
            CT_PHIEUNHAPSACH_DTO ctpns_dto = new CT_PHIEUNHAPSACH_DTO();
            ctpns_dto.MAPHIEUNHAP = ctpns.MAPHIEU;
            ctpns_dto.MASACH = ctpns.MASACH;
            ctpns_dto.SLNHAP = ctpns.SLNHAP;
            ctpns_dto.THANHTIEN = Convert.ToDouble(ctpns.THANHTIEN);
            return ctpns_dto;

        }

        public CT_PHIEUNHAPSACH convertBackFromDTO(CT_PHIEUNHAPSACH_DTO ctpns_dto)
        {
            CT_PHIEUNHAPSACH ctpns = new CT_PHIEUNHAPSACH();
            ctpns.MAPHIEU = ctpns_dto.MAPHIEUNHAP;
            ctpns.MASACH = ctpns_dto.MASACH;
            ctpns.SLNHAP = ctpns_dto.SLNHAP;
            ctpns.THANHTIEN = ctpns_dto.THANHTIEN;
            return ctpns;

        }
    }
}