using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class LoaiSachRepository : IRepository<LOAISACH>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(LOAISACH item)
        {
            db.LOAISACHes.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            db.LOAISACHes.DeleteOnSubmit(db.LOAISACHes.FirstOrDefault(t => t.MALS.Equals(ma)));
            db.SubmitChanges();
        }

        public LOAISACH Get(string ma)
        {
            return db.LOAISACHes.Where(t => t.MALS.Equals(ma)).FirstOrDefault();
        }

        public List<LOAISACH> List()
        {
            return db.LOAISACHes.ToList();
        }

        public void Update(LOAISACH item, string ma)
        {
            LOAISACH ls = db.LOAISACHes.Where(t => t.MALS.Equals(ma)).FirstOrDefault();
            ls.MALS = item.MALS;
            ls.TENLS = item.TENLS;
            db.SubmitChanges();
        }

        public LOAISACH_DTO convertToDTO(LOAISACH ls)
        {
            LOAISACH_DTO ls_dto = new LOAISACH_DTO();
            ls_dto.MALS = ls.MALS;
            ls_dto.TENLS = ls.TENLS;
            return ls_dto;
        }

        public LOAISACH convertBackFromDTO(LOAISACH_DTO ls_dto)
        {
            LOAISACH ls = new LOAISACH();
            ls.MALS = ls_dto.MALS;
            ls.TENLS = ls_dto.TENLS;
            return ls;
        }
    }
}