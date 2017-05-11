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
    public class KindController : ApiController
    {
        IRepository<Kind> _rep = new KindRepository();
        // GET api/Kind
        public IEnumerable<Kind> Get()
        {
            return _rep.GetAll();
        }

        // GET api/Kind/5
        public Kind Get(int id)
        {
            return _rep.GetById(id);
        }
    }
}