using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class BreedRepository: IRepository<Breed>
    {
        DataContext db;

        public BreedRepository()
        {
            this.db = new DataContext();
        }

        public List<Breed> GetAll()
        {
            List<Breed> allBreeds = db.Set<Breed>().ToList();

            return allBreeds;
        }

        public Breed GetById(int id)
        {
            var breed = db.Breeds.Find(id);

            return breed;
        }

        public void Add(Breed breed){}
        public void Remove(int id){}
        public void Update(Breed breed){}
        
    }
}
