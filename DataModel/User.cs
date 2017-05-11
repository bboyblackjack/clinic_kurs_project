using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataModel
{
    public class User 
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Application> Applications { get; set; }
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Record> Records { get; set; }



        public User()
        {
            Applications = new List<Application>();
            Pets = new List<Pet>();
            Records = new List<Record>();
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

       
    }
}
