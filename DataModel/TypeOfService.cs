using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class TypeOfService
    {
        public int TypeOfServiceId { get; set; }
        public string Name { get; set; }

        public ICollection<Service> Services { get; set; }

        public TypeOfService()
        {
            Services = new List<Service>();
        }
    }
}
