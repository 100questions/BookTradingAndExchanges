using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class NhaCungCapRepository : IRepository<NHACUNGCAP>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(NHACUNGCAP item)
        {
            db.NHACUNGCAPs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.NHACUNGCAPs.DeleteOnSubmit(db.NHACUNGCAPs.Where(t => t.MANCC.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public NHACUNGCAP Get(string ma)
        {
            return db.NHACUNGCAPs.Where(t => t.MANCC.Equals(ma)).FirstOrDefault();
        }

        public List<NHACUNGCAP> List()
        {
            return db.NHACUNGCAPs.ToList();
        }

        public void Update(NHACUNGCAP item, string ma)
        {
            NHACUNGCAP ncc = db.NHACUNGCAPs.FirstOrDefault(t => t.MANCC.Equals(ma));
            ncc.MANCC = item.MANCC;
            ncc.TENNCC = item.TENNCC;
            ncc.DIACHI = item.DIACHI;
            ncc.SDT = item.SDT;
            db.SubmitChanges();
        }


        public NHACUNGCAP_DTO convertToDTO(NHACUNGCAP ncc)
        {
            NHACUNGCAP_DTO ncc_dto = new NHACUNGCAP_DTO();
            ncc_dto.MANCC = ncc.MANCC;
            ncc_dto.TENNCC = ncc.TENNCC;
            ncc_dto.DIACHI = ncc.DIACHI;
            ncc_dto.SDT = ncc.SDT;
            return ncc_dto;

        }
    }
}