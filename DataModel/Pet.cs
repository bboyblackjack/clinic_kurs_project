using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int KindId { get; set; }
        public Kind Kind { get; set; }

        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        public int ColorId { get; set; }
        public Color Color { get; set; }


        public ICollection<Application> Applications { get; set; }
        public ICollection<Card> Cards { get; set; }

        public Pet()
        {
            Applications = new List<Application>();
            Cards = new List<Card>();
        }
    }
}
