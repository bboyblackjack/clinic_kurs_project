using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class KindRepository: IRepository<Kind>
    {
        DataContext db;

        public KindRepository()
        {
            this.db = new DataContext();
        }

        public List<Kind> GetAll()
        {
            List<Kind> allKinds = db.Set<Kind>().ToList();

            return allKinds;
        }

        public Kind GetById(int id)
        {
            var kind = db.Kinds.Find(id);

            return kind;
        }

        public void Add(Kind kind) { }
        public void Remove(int id) { }
        public void Update(Kind kind) { }
    }
}
