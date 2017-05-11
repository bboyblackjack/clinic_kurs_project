using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DataAccess
{
    public class RoleRepository
    {
        public static List<Role> getRoles()
        {
            var db = new DataContext();
            List<Role> allRoles = db.Set<Role>().ToList();

            return allRoles;
        }

        public static Role getRoleById(int id)
        {
            var db = new DataContext();
            var role = db.Roles.Find(id);

            return role;
        }

        public void Add(Role role) { }
        public void Remove(int id) { }
        public void Update(Role role) { }
    }
}
