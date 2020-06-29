using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreServices.IRepository
{
    public interface IRepository<T>
    {
        List<T> List();

        T Get(string ma);

        void Add(T item);

        void Delete(string ma);

        void Update(T item, string ma);
    }
}
