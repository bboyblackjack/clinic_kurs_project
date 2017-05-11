using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class RecordsModel
    {
        public int RecordId { get; set; }
        public string DoctorName { get; set; }
        public string Service { get; set; }
        public int CardId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
