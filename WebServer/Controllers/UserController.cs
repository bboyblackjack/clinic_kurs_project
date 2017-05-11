using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebServer.Controllers
{
    public class UserController : ApiController
    {
        UserRepository _rep = new UserRepository();
        // GET api/user
        public IEnumerable<User> Get()
        {
            return _rep.GetAll();
        }

        // GET api/user/5
        public User Get(int id)
        {
            return _rep.GetById(id);
        }

        //POST
        public int Post([FromBody]User user)
        {

            User realUser = _rep.GetByEmail(user.Email);
            if (realUser != null && user.Password == realUser.Password && realUser.RoleId == 2)
            {
                return realUser.UserId;
            }
            return -1;
        }
    }
}