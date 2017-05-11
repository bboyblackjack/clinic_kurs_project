using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Breed
    {
        public int BreedId { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public Breed()
        {
            Pets = new List<Pet>();
        }
    }
}
