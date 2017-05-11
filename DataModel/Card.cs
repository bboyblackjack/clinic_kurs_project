using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Card
    {
        public int CardId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public ICollection<Record> Records { get; set; }

        public Card()
        {
            Records = new List<Record>();
        }
    }
}
