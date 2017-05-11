using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Time
    {
        public int TimeId { get; set; }
        public string Interval { get; set; }

        public ICollection<Application> Applications { get; set; }
        public ICollection<Record> Records { get; set; }

        public Time()
        {
            Applications = new List<Application>();
            Records = new List<Record>();
        }
    }
}
