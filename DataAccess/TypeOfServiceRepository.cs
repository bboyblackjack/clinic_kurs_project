using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class TypeOfServiceRepository: IRepository<TypeOfService>
    {
        DataContext db;

        public TypeOfServiceRepository()
        {
            this.db = new DataContext();
        }

        public List<TypeOfService> GetAll()
        {
            List<TypeOfService> allTypes = db.Set<TypeOfService>().ToList();

            return allTypes;
        }

        public TypeOfService GetById(int id)
        {
            var type = db.TypesOfServices.Find(id);

            return type;
        }

        public void Add(TypeOfService typeOfService) { }
        public void Remove(int id) { }
        public void Update(TypeOfService typeOfService) { }
    }
}
