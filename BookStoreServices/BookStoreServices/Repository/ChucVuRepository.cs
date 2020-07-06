using BookStoreServices.DTO;
using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class ChucVuRepository : IRepository<CHUCVU>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(CHUCVU item)
        {
            db.CHUCVUs.InsertOnSubmit(item);
            db.SubmitChanges(); 
        }

        public void Delete(string ma)
        {
            db.CHUCVUs.DeleteOnSubmit(db.CHUCVUs.Where(t => t.MACV.Equals(ma)).FirstOrDefault());
            db.SubmitChanges();
        }

        public CHUCVU Get(string ma)
        {
            return db.CHUCVUs.Where(t => t.MACV.Equals(ma)).FirstOrDefault();
        }

        public List<CHUCVU> List()
        {
            return db.CHUCVUs.ToList();
        }

        public void Update(CHUCVU item, string ma)
        {
            CHUCVU cv = db.CHUCVUs.Where(t => t.MACV.Equals(ma)).FirstOrDefault();
            cv.MACV = item.MACV;
            cv.TENCV = item.TENCV;
            db.SubmitChanges();
        }

        public CHUCVU_DTO convertToDTO(CHUCVU cv)
        {
            CHUCVU_DTO cv_dto = new CHUCVU_DTO();
            cv_dto.MACV = cv.MACV;
            cv_dto.TENCN = cv.TENCV;
            return cv_dto;
        }

        public CHUCVU convertBackFromDTO(CHUCVU_DTO cv_dto)
        {
            CHUCVU cv = new CHUCVU();
            cv.MACV = cv_dto.MACV;
            cv.TENCV = cv_dto.TENCN;
            return cv;

        }
    }
}