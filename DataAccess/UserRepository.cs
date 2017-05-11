using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class UserRepository : IRepository<User>
    {
        DataContext db;

        public UserRepository()
        {
            this.db = new DataContext();
        }

        public List<User> GetAll()
        {
            List<User> allUsers = db.Set<User>().ToList();

            return allUsers;
        }

        public User GetById(int id)
        {
            var user = db.Users.Find(id);

            return user;
        }

        public User GetByEmail(string Email)
        {
            var user = db.Users.SingleOrDefault(usr => usr.Email == Email);
            return user;
        }

        public void Remove(int id)
        {
            var user = db.Users.Find(id);

            db.Users.Remove(user);
            db.SaveChanges();
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}
