using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient
{
    public class UserName
    {
        public string FullName { get; set; }
        public int UserId { get; set; }
         public UserName(int _userId, string _fullName)
        {
            UserId = _userId;
            FullName = _fullName;
        }
        public override string ToString()
        {
            return this.UserId.ToString();
        }
    }
}
