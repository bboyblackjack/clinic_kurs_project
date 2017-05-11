using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Application
    {
        public int ApplicationId { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }

        public int TimeId { get; set; }
        public Time Time { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
