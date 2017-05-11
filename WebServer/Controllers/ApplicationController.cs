using DataAccess;
using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebServer.Controllers
{
    public class ApplicationController : ApiController
    {
        ApplicationRepository _rep = new ApplicationRepository();
        UserRepository _user = new UserRepository();
        PetRepository _pet = new PetRepository();
        ServiceRepository _service = new ServiceRepository();
        TimeRepository _time = new TimeRepository();

        //GET api/Application
        public IEnumerable<Application> Get()
        {
            return _rep.GetAll();
        }

        public void Post([FromBody]string json)
        {
            Application app = JsonConvert.DeserializeObject<Application>(json);
            _rep.Add(app);
        }

        //GET api/Application/5
        public Application Get(int id)
        {
            var app = _rep.GetById(id);
            app.User = _user.GetById(app.UserId);
            app.Pet = _pet.GetById(app.PetId);
            app.Service = _service.GetById(app.ServiceId);
            app.Time = _time.GetById(app.TimeId);
            return app;
        }

        public IEnumerable<Application> Get(int id, int flag)
        {
            var apps = _rep.GetByUserId(id);
            foreach (var p in apps)
            {
                p.Time = _time.GetById(p.TimeId);
                p.Pet = _pet.GetById(p.PetId);
                p.Service = _service.GetById(p.ServiceId);
            }
            return apps;
        }

        //DELETE api/application
        public bool Delete([FromBody] int id)
        {
            try
            {
                _rep.Remove(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}