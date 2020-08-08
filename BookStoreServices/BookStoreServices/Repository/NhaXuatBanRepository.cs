using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class NhaXuatBanRepository : IRepository<NHAXUATBAN>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(NHAXUATBAN item)
        {
            db.NHAXUATBANs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.NHAXUATBANs.DeleteOnSubmit(db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public NHAXUATBAN Get(string ma)
        {
            return db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault();
        }

        public List<NHAXUATBAN> List()
        {
            return db.NHAXUATBANs.ToList();
        }

        public void Update(NHAXUATBAN item, string ma)
        {
            NHAXUATBAN nxb = db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault();
            nxb.MANXB = item.MANXB;
            nxb.TENNXB = item.TENNXB;
            nxb.DIACHI = item.DIACHI;
            nxb.SDT = item.SDT;
            db.SubmitChanges();
        }

        public NHAXUATBAN_DTO convertToDTO(NHAXUATBAN nxb)
        {
            NHAXUATBAN_DTO nxb_dto = new NHAXUATBAN_DTO();
            nxb_dto.MANXB = nxb.MANXB;
            nxb_dto.TENNXB = nxb.TENNXB;
            nxb_dto.DIACHI = nxb.DIACHI;
            nxb_dto.SDT = nxb.SDT;
            return nxb_dto;
        }
        public NHAXUATBAN convertBackFromDTO(NHAXUATBAN_DTO nxb_dto)
        {
            NHAXUATBAN nxb = new NHAXUATBAN();
            nxb.MANXB = nxb_dto.MANXB;
            nxb.TENNXB = nxb_dto.TENNXB;
            nxb.DIACHI = nxb_dto.DIACHI;
            nxb.SDT = nxb_dto.SDT;
            return nxb;
        }
    }
}