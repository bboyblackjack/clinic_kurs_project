using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IRepository<T> where T: class
    {
        T GetById(int id);
        List<T> GetAll();
        void Add(T element);
        void Remove(int id);
        void Update(T element);
    }
}
