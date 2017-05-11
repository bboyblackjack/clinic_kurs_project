using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.Services
{
    public class AuthService
    {
        private static AuthService _instance;

        private readonly string _userName;
        private readonly int _id;

        private AuthService(string user, string id)
        {
            _userName = user;
            _id = Convert.ToInt32(id);
        }

        public static AuthService Instance
        {
            get { return _instance; }
        }

        public string UserName
        {
            get { return _userName; }
        }

        public int UserId
        {
            get { return _id; }
        }

        public static void CreateAuthService(string user, string id)
        {
            _instance = new AuthService(user, id);
        }
    }
}
