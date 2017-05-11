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
    public class TypeOfServiceController : ApiController
    {
        IRepository<TypeOfService> _rep = new TypeOfServiceRepository();
        // GET api/TypeOfService
        public IEnumerable<TypeOfService> Get()
        {
            return _rep.GetAll();
        }

        // GET api/TypeOfService/5
        public TypeOfService Get(int id)
        {
            return _rep.GetById(id);
        }
    }
}