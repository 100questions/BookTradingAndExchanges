using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class PhieuDoiTraSachRepository : IRepository<PHIEUDOITRA>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(PHIEUDOITRA item)
        {
            db.PHIEUDOITRAs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.PHIEUDOITRAs.DeleteOnSubmit(db.PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }


        public PHIEUDOITRA Get(string ma)
        {
            return db.PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault();
        }

        public List<PHIEUDOITRA> List()
        {
            return db.PHIEUDOITRAs.ToList();
        }

        public void Update(PHIEUDOITRA item, string ma)
        {
            PHIEUDOITRA pdt = db.PHIEUDOITRAs.Where(t => t.MAPHIEUDOI.Equals(ma)).FirstOrDefault();
            pdt.MAPHIEUDOI = item.MAPHIEUDOI;
            pdt.MANV = item.MANV;
            pdt.NGAYLAPPHIEU = item.NGAYLAPPHIEU;
            db.SubmitChanges();
        }

        public PHIEUDOITRASACH_DTO convertToDTO(PHIEUDOITRA pdt)
        {
            PHIEUDOITRASACH_DTO pdt_dto = new PHIEUDOITRASACH_DTO();
            pdt_dto.MAPHIEUDOI = pdt.MAPHIEUDOI;
            pdt_dto.MANV = pdt.MANV;
            pdt_dto.NGAYLAPPHIEU = pdt.NGAYLAPPHIEU;
            return pdt_dto;
        }

        public PHIEUDOITRA convertBackFromDTO(PHIEUDOITRASACH_DTO pdt_dto)
        {
            PHIEUDOITRA pdt = new PHIEUDOITRA();
            pdt.MAPHIEUDOI = pdt_dto.MAPHIEUDOI;
            pdt.MANV = pdt_dto.MANV;
            pdt.NGAYLAPPHIEU = pdt_dto.NGAYLAPPHIEU;
            return pdt;
        }
    }
}