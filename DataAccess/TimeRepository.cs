using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class TimeRepository: IRepository<Time>
    {
        DataContext db;

        public TimeRepository()
        {
            this.db = new DataContext();
        }

        public List<Time> GetAll()
        {
            List<Time> allTimes = db.Set<Time>().ToList();

            return allTimes;
        }

        public Time GetById(int id)
        {
            var time = db.Times.Find(id);

            return time;
        }

        public void Add(Time time) { }
        public void Remove(int id) { }
        public void Update(Time time) { }
    }
}
