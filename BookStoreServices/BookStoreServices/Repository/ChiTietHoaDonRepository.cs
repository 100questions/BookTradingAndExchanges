using BookStoreServices.IRepository;
using BookStoreServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreServices.Repository
{
    public class ChiTietHoaDonRepository : IRepository<CHITIETHOADON>
    {
        BookStoreDataContext db = new BookStoreDataContext();
        public void Add(CHITIETHOADON item)
        {
            db.CHITIETHOADONs.InsertOnSubmit(item);
            db.SubmitChanges();
        }

        public void Delete(string ma)
        {
            throw new NotImplementedException();
        }

        public CHITIETHOADON Get(string ma)
        {
            throw new NotImplementedException();
        }

        public List<CHITIETHOADON> List()
        {
            throw new NotImplementedException();
        }

        public void Update(CHITIETHOADON item, string ma)
        {
            throw new NotImplementedException();
        }
    }
}