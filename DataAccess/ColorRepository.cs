using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class ColorRepository: IRepository<Color>
    {
        DataContext db;

        public ColorRepository()
        {
            this.db = new DataContext();
        }

        public List<Color> GetAll()
        {
            List<Color> allColors = db.Set<Color>().ToList();

            return allColors;
        }

        public Color GetById (int id)
        {
            var color = db.Colors.Find(id);

            return color;
        }

        public void Add(Color color) {
            db.Colors.Add(color);
            db.SaveChanges();
        }
        public void Remove(int id) { }
        public void Update(Color color) { }
    }
}
