using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class HoaDonRepository : IRepository<HOADON_DTO>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(HOADON_DTO item)
        {
            HOADON hd = convertBackFromDTO(item);
            db.HOADONs.InsertOnSubmit(hd);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.NHAXUATBANs.DeleteOnSubmit(db.NHAXUATBANs.Where(t => t.MANXB.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public HOADON_DTO Get(string ma)
        {
            return db.HOADONs.Where(t => t.MAHD.Equals(ma)).Select(x => convertToDTO(x)).FirstOrDefault();
        }

        public List<HOADON_DTO> List()
        {
            return db.HOADONs.Select(x => convertToDTO(x)).ToList();
        }

        public void Update(HOADON_DTO item, string ma)
        {
            HOADON hd = db.HOADONs.Where(t => t.MAHD.Equals(ma)).FirstOrDefault();
            hd.MAHD = item.MAHD;
            hd.MAKH = item.MAKH;
            hd.NGAYLAPHD = DateTime.Parse(item.NGAYLAPHD.ToString());
            //double validValue = null;
            //hd.THANHTIEN = double.TryParse(item.THANHTIEN, out double va)
            

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
            //hd.NGAYLAPHD = DateTime.Parse(hd_dto.NGAYLAPHD.ToString());
            hd.THANHTIEN = Convert.ToDouble(hd.THANHTIEN);
            return hd_dto;
        }
    }
}