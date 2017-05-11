using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Color
    {
        public int ColorId { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public Color()
        {
            Pets = new List<Pet>();
        }
    }
}
