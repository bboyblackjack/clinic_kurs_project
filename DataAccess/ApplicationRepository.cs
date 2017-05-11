using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class ApplicationRepository: IRepository<Application>
    {
        DataContext db;

        public ApplicationRepository()
        {
            this.db = new DataContext();
        }

        public List<Application> GetAll()
        {
            List<Application> allApplications = db.Set<Application>().ToList();
            return allApplications;
        }

        public Application GetById(int id)
        {
            var application = db.Applications.Find(id);
            return application;
        }

        public void Remove(int id)
        {
            var application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
        }

        public void Update(Application application)
        {
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Application application)
        {
            db.Applications.Add(application);
            db.SaveChanges();
        }

        public IEnumerable<Application> GetByUserId(int id)
        {
            List<Application> apps = db.Set<Application>().Where(usr => usr.UserId == id).ToList();
            return apps;
        }
    }
}
