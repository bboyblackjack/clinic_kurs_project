using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class Record
    {

        public int RecordId { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int TimeId { get; set; }
        public Time Time { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

    }
}
