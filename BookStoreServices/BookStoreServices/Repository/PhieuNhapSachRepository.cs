using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class PhieuNhapSachRepository : IRepository<PHIEUNHAPSACH>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(PHIEUNHAPSACH item)
        {
            db.PHIEUNHAPSACHes.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.PHIEUNHAPSACHes.DeleteOnSubmit(db.PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public PHIEUNHAPSACH Get(string ma)
        {
            return db.PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault();
        }

        public List<PHIEUNHAPSACH> List()
        {
            return db.PHIEUNHAPSACHes.ToList();
        }

        public void Update(PHIEUNHAPSACH item, string ma)
        {
            PHIEUNHAPSACH pns = db.PHIEUNHAPSACHes.Where(t => t.MAPHIEU.Equals(ma)).FirstOrDefault();
            pns.MAPHIEU = item.MAPHIEU;
            pns.MANV = item.MANV;
            DateTime validValue;
            pns.NGAYNHAP = DateTime.TryParse(item.NGAYNHAP.ToString(), out validValue) ? validValue : (DateTime?)null;
            pns.THANHTIENPHIEUNHAP = item.THANHTIENPHIEUNHAP;
            db.SubmitChanges();
        }

        public PHIEUNHAPSACH_DTO convertToDTO(PHIEUNHAPSACH pns)
        {
            PHIEUNHAPSACH_DTO pns_dto = new PHIEUNHAPSACH_DTO();
            pns_dto.MAPHIEUNHAP = pns.MAPHIEU;
            pns_dto.MANV = pns.MANV;
            DateTime validValue;
            pns_dto.NGAYNHAP = (DateTime.TryParse(pns.NGAYNHAP.ToString(), out validValue) ? validValue : (DateTime?)null);
            pns_dto.THANHTIENPHIEUNHAP = Convert.ToDouble(pns.THANHTIENPHIEUNHAP);
            return pns_dto;
        }
    }
}