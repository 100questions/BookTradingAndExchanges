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

        public void DeleteCTPNs(string maPNS)
        {
            db.CT_PHIEUNHAPSACHes.DeleteAllOnSubmit(db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(maPNS)).ToList());
            db.SubmitChanges();
        }

        public void DeletePNS(string maPNS, string maSP)
        {
            db.CT_PHIEUNHAPSACHes.DeleteOnSubmit(db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(maPNS)).Where(t => t.MASACH.Equals(maSP)).FirstOrDefault());
            db.SubmitChanges();
        }

        public List<CT_PHIEUNHAPSACH> GetCTPNSs(string ma)
        {
            return db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).ToList();
        }

        public CT_PHIEUNHAPSACH GetCTPNS(string maPNS, string maSach)
        {
            return db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(maPNS) && t.MASACH.Equals(maSach)).FirstOrDefault();
        }

        public List<CT_PHIEUNHAPSACH> List()
        {
            return db.CT_PHIEUNHAPSACHes.ToList();
        }

        public void UpdateCTPNS(CT_PHIEUNHAPSACH item, string maPNS, string maSach)
        {
            CT_PHIEUNHAPSACH ctpns = db.CT_PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(maPNS)).Where(t => t.MASACH.Equals(maSach)).FirstOrDefault();
            ctpns.MAPHIEU = item.MAPHIEU;
            ctpns.MASACH = item.MASACH;
            ctpns.SLNHAP = item.SLNHAP;
            ctpns.THANHTIEN = item.THANHTIEN;
            db.SubmitChanges();
        }


        public CT_PHIEUNHAPSACH_DTO convertToDTO(CT_PHIEUNHAPSACH ctpns)
        {
            CT_PHIEUNHAPSACH_DTO ctpns_dto = new CT_PHIEUNHAPSACH_DTO();
            ctpns_dto.MAPHIEU = ctpns.MAPHIEU;
            ctpns_dto.MASACH = ctpns.MASACH;
            ctpns_dto.SLNHAP = ctpns.SLNHAP;
            ctpns_dto.THANHTIEN = Convert.ToDouble(ctpns.THANHTIEN);
            return ctpns_dto;

        }
        

        public CT_PHIEUNHAPSACH convertBackFromDTO(CT_PHIEUNHAPSACH_DTO ctpns_dto)
        {
            CT_PHIEUNHAPSACH ctpns = new CT_PHIEUNHAPSACH();
            ctpns.MAPHIEU = ctpns_dto.MAPHIEU;
            ctpns.MASACH = ctpns_dto.MASACH;
            ctpns.SLNHAP = ctpns_dto.SLNHAP;
            ctpns.THANHTIEN = ctpns_dto.THANHTIEN;
            return ctpns;

        }



        public CT_PHIEUNHAPSACH Get(string ma)
        {
            throw new NotImplementedException();
        }

        public void Delete(string ma)
        {
            throw new NotImplementedException();
        }

        public void Update(CT_PHIEUNHAPSACH item, string ma)
        {
            throw new NotImplementedException();
        }
    }
}