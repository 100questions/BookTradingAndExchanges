using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class ChiTietPhieuDoiTraSachRepository : IRepository<CT_PHIEUDOITRA>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(CT_PHIEUDOITRA item)
        {
            db.CT_PHIEUDOITRAs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.CT_PHIEUDOITRAs.DeleteOnSubmit(db.CT_PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public CT_PHIEUDOITRA Get(string ma)
        {
            return db.CT_PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault();
        }

        public List<CT_PHIEUDOITRA> List()
        {
            return db.CT_PHIEUDOITRAs.ToList();
        }

        public void Update(CT_PHIEUDOITRA item, string ma)
        {
            CT_PHIEUDOITRA ctpdt = db.CT_PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault();
            ctpdt.MASP = item.MASP;
            ctpdt.MAPHIEUDOI = item.MAPHIEUDOI;
            ctpdt.MAHD = item.MAHD;
            ctpdt.SL = item.SL;
            db.SubmitChanges();
        }

        public CT_PHIEUDOITRA convertBackFromDTO(CT_PHIEUDOITRASACH_DTO ctpdt_dto)
        {
            CT_PHIEUDOITRA ctpdt = new CT_PHIEUDOITRA();
            ctpdt.MASP = ctpdt_dto.MASP;
            ctpdt.MAPHIEUDOI = ctpdt_dto.MAPHIEUDOI;
            ctpdt.MAHD = ctpdt_dto.MAHD;
            ctpdt.SL = ctpdt_dto.SL;
            return ctpdt;
        }

        public CT_PHIEUDOITRASACH_DTO convertToDTO(CT_PHIEUDOITRA ctpdt)
        {
            CT_PHIEUDOITRASACH_DTO ctpdt_dto = new CT_PHIEUDOITRASACH_DTO();
            ctpdt_dto.MASP = ctpdt.MASP;
            ctpdt_dto.MAPHIEUDOI = ctpdt.MAPHIEUDOI;
            ctpdt_dto.MAHD = ctpdt.MAHD;
            ctpdt_dto.SL = ctpdt.SL;
            return ctpdt_dto;
        }
    }
}