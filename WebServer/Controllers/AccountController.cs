using DataAccess;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebServer.Models;

namespace WebServer.Controllers
{
    public class AccountController : ApiController
    {
        UserRepository _rep = new UserRepository();

        [HttpPost]
        public string Post([FromBody]string json)
        {

            User user = JsonConvert.DeserializeObject<User>(json);
            User realUser = _rep.GetByEmail(user.Email);
            if(realUser!= null && user.Password == realUser.Password)
            {
                return realUser.Login + ";" + realUser.UserId;
            }
            return "empty";
        }

        [HttpGet]
        public User Get(int id)
        {
            return _rep.GetById(id);
        }

        [HttpPost]
        public void Update(int id, [FromBody]string json)
        {
            User user = JsonConvert.DeserializeObject<User>(json);
            user.UserId = id;
            user.RoleId = 1;
            _rep.Update(user);
        }

        

       
    }
}