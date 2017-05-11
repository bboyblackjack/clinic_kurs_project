using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class PetRepository: IRepository<Pet>
    {
        DataContext db;

        public PetRepository()
        {
            this.db = new DataContext();
        }

        public List<Pet> GetAll()
        {
            List<Pet> allPets = db.Set<Pet>().ToList();

            return allPets;
        }

        public Pet GetById(int id)
        {
            var pet = db.Pets.Find(id);

            return pet;
        }

        public IEnumerable<Pet> GetByUserId(int id)
        {
            List<Pet> pets = db.Set<Pet>().Where(usr => usr.UserId == id).ToList();
            return pets;
        }

        public void Remove(int id)
        {
            var pet = db.Pets.Find(id);

            db.Pets.Remove(pet);
            db.SaveChanges();
        }

        public void Update(Pet pet)
        {
            db.Entry(pet).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Pet pet)
        {
            db.Pets.Add(pet);
            db.SaveChanges();
        }
    }
}
