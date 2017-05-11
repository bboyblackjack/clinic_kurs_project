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
    public class BreedController : ApiController
    {
        IRepository<Breed> _rep = new BreedRepository();
     
         //GET api/Breed
        public IEnumerable<Breed> Get()
        {
            return _rep.GetAll();
        }

         //GET api/Breed/5
        public Breed Get(int id)
        {
            return _rep.GetById(id);
        }
    }
}