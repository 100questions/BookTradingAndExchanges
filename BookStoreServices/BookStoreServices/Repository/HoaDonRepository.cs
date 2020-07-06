using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class HoaDonRepository : IRepository<HOADON>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(HOADON item)
        {
            db.HOADONs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.NHAXUATBANs.DeleteOnSubmit(db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public HOADON Get(string ma)
        {
            return db.HOADONs.Where(t => t.MAHD.Equals(ma)).FirstOrDefault();
        }

        public List<HOADON> List()
        {
            return db.HOADONs.ToList();
        }

        public void Update(HOADON item, string ma)
        {
            HOADON hd = db.HOADONs.Where(t => t.MAHD.Equals(ma)).FirstOrDefault();
            hd.MAHD = item.MAHD;
            hd.MAKH = item.MAKH;
            hd.NGAYLAPHD = DateTime.Parse(item.NGAYLAPHD.ToString());
            hd.THANHTIEN = Convert.ToDouble(item.THANHTIEN);
            db.SubmitChanges();
        }

        public HOADON_DTO convertToDTO(HOADON hd)
        {
            HOADON_DTO hd_dto = new HOADON_DTO();
            hd_dto.MAHD = hd.MAHD;
            hd_dto.MAKH = hd.MAKH;
            DateTime validValue;
            hd_dto.NGAYLAPHD = DateTime.TryParse(hd.NGAYLAPHD.ToString(), out validValue) ? validValue : (DateTime?)null;
            hd_dto.THANHTIEN = Convert.ToDouble(hd.THANHTIEN);
            return hd_dto;
        }

        public HOADON convertBackFromDTO(HOADON_DTO hd)
        {
            HOADON hd_dto = new HOADON();
            hd.MAHD = hd_dto.MAHD;
            hd.MAKH = hd_dto.MAKH;
            DateTime validValue;
            hd.NGAYLAPHD = DateTime.TryParse(hd_dto.NGAYLAPHD.ToString(), out validValue) ? validValue : (DateTime?)null;
            hd.THANHTIEN = Convert.ToDouble(hd.THANHTIEN);
            return hd_dto;
        }
    }
}