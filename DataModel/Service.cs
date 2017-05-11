using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int TypeOfServiceId { get; set; }
        public TypeOfService TypeOfService { get; set; }

        public ICollection<Application> Applications { get; set; }
        public ICollection<Record> Records { get; set; }

        public Service()
        {
            Applications = new List<Application>();
            Records = new List<Record>();
        }
    }
}
