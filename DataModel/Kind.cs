using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Kind
    {
        public int KindId { get; set; }
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }

        public Kind()
        {
            Pets = new List<Pet>();
        }
    }
}
