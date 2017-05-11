using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class RecordRepository: IRepository<Record>
    {
        DataContext db;

        public RecordRepository()
        {
            this.db = new DataContext();
        }

        public List<Record> GetAll()
        {
            List<Record> records = db.Set<Record>().ToList();

            return records;
        }

        public IEnumerable<Record> GetAllData()
        {
            IEnumerable<Record> allRecords = db.Set<Record>().ToList();

            return allRecords;
        }
        

        public Record GetById (int id)
        {
            var record = db.Records.Find(id);

            return record;
        }

        public void Remove (int id)
        {
            var record = db.Records.Find(id);

            db.Records.Remove(record);
            db.SaveChanges();
        }

        public void Update (Record record)
        {
            db.Entry(record).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add (Record record)
        {
            db.Records.Add(record);
            db.SaveChanges();
        }
    }
}
