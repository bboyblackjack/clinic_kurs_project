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
    public class ServiceController : ApiController
    {
        ServiceRepository _rep = new ServiceRepository();
        // GET api/Service
        public IEnumerable<Service> Get()
        {
            return _rep.GetAll();
        }

        // GET api/Service/5
        public Service Get(int id)
        {
            return _rep.GetById(id);
        }

        public IEnumerable<Service> Get(int id, int flag)
        {
            var services = _rep.GetByTypeId(id);
            return services;
        }
    }
}