using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesktopClient
{
    public class AllCardsModel
    {
        public int CardId { get; set; }
        public string PetName { get; set; }
        public string UserName { get; set; }
    }
}
