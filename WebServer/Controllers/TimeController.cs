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
    public class TimeController : ApiController
    {
        IRepository<Time> _rep = new TimeRepository();
        // GET api/Time
        public IEnumerable<Time> Get()
        {
            return _rep.GetAll();
        }

        // GET api/Time/5
        public Time Get(int id)
        {
            return _rep.GetById(id);
        }
    }
}