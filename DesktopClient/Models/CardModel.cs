using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace DesktopClient
{
    public class CardModel
    {
        public int CardId { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string UserName { get; set; }
        public string PetName { get; set; }
        public string Birthday { get; set; }
        public string Kind { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }

    }
}
