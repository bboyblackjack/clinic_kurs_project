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
    public class ColorController : ApiController
    {
        IRepository<Color> _rep = new ColorRepository();
        // GET api/Color
        public IEnumerable<Color> Get()
        {
            return _rep.GetAll();
        }

        // GET api/Color/5
        public Color Get(int id)
        {
            return _rep.GetById(id);
        }
    }
}