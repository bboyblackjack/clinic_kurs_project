using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class PetName
    {
        public string Name { get; set; }
        public int PetId { get; set; }

        public PetName (int _petId, string _name)
        {
            PetId = _petId;
            Name = _name;
        }

        public override string ToString()
        {
            return this.PetId.ToString();
        }
    }
}
