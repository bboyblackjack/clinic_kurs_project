using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataModel;
using Newtonsoft.Json;
using DataAccess;

namespace WebServer.Controllers
{
    public class RegisterController : ApiController
    {
        UserRepository _rep = new UserRepository();
        // POST api/<controller>
        public void Post([FromBody]string json)
        {
            User user = JsonConvert.DeserializeObject<User>(json);
            user.RoleId = 1;
            _rep.Add(user);
            //EmailNotifier.IEmailNotifier mail = new EmailNotifier.MailRuNotifier("abc@mail.ru", "password");
           // mail.Send("Регистрация проведена!", "Регистрация успешно завершена", user.Email.ToString());
        }
    }
}