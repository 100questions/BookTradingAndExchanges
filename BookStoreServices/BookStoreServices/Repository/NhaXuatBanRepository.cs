using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class NhaXuatBanRepository : IRepository<NHAXUATBAN_DTO>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(NHAXUATBAN_DTO item)
        {
            NHAXUATBAN nxb = convertBackFromDTO(item);
            db.NHAXUATBANs.InsertOnSubmit(nxb);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.NHAXUATBANs.DeleteOnSubmit(db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public NHAXUATBAN_DTO Get(string ma)
        {
            return db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).Select(x => convertToDTO(x)).FirstOrDefault();
        }

        public List<NHAXUATBAN_DTO> List()
        {
            return db.NHAXUATBANs.Select(t => convertToDTO(t)).ToList();
        }

        public void Update(NHAXUATBAN_DTO item, string ma)
        {
            NHAXUATBAN nxb = new NHAXUATBAN();
            nxb.MANXB = item.MANXB;
            nxb.TENNXB = item.TENNXB;
            nxb.DIACHI = item.DIACHI;
            nxb.SODIENTHOAI = item.SDT;
            db.SubmitChanges();
        }

        public NHAXUATBAN_DTO convertToDTO(NHAXUATBAN nxb)
        {
            NHAXUATBAN_DTO nxb_dto = new NHAXUATBAN_DTO();
            nxb_dto.MANXB = nxb.MANXB;
            nxb_dto.TENNXB = nxb.TENNXB;
            nxb_dto.DIACHI = nxb.DIACHI;
            nxb_dto.SDT = nxb.SODIENTHOAI;
            return nxb_dto;
        }
        public NHAXUATBAN convertBackFromDTO(NHAXUATBAN_DTO nxb_dto)
        {
            NHAXUATBAN nxb = new NHAXUATBAN();
            nxb.MANXB = nxb_dto.MANXB;
            nxb.TENNXB = nxb_dto.TENNXB;
            nxb.DIACHI = nxb_dto.DIACHI;
            nxb.SODIENTHOAI = nxb_dto.SDT;
            return nxb;
        }
    }
}