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
    public class PetController : ApiController
    {
        PetRepository _rep = new PetRepository();
        KindRepository _kind = new KindRepository();
        BreedRepository _breed = new BreedRepository();
        ColorRepository _color = new ColorRepository();
        UserRepository _user = new UserRepository();
        // GET: api/Pet
        public IEnumerable<Pet> Get()
        {
            return _rep.GetAll();
        }

        // GET api/Pet/5
        public Pet Get(int id)
        {
            var p = _rep.GetById(id);
            p.Kind = _kind.GetById(p.KindId);
            p.Breed = _breed.GetById(p.BreedId);
            p.Color = _color.GetById(p.ColorId);
            p.User = _user.GetById(p.UserId);
            return p;
           // return _rep.GetById(id);
        }

        public IEnumerable<Pet> Get(int id, int flag)
        {
            var pets = _rep.GetByUserId(id);
            foreach(var p in pets)
            {
                p.Kind = _kind.GetById(p.KindId);
                p.Breed = _breed.GetById(p.BreedId);
                p.Color = _color.GetById(p.ColorId);
            }
            return pets;
        }

        public void Post([FromBody]string json)
        {
            Pet pet = JsonConvert.DeserializeObject<Pet>(json);
            _rep.Add(pet);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _rep.Remove(id);
        }

        [HttpPut]
        public void Update(int id, [FromBody]string json)
        {
            Pet pet = JsonConvert.DeserializeObject<Pet>(json);
            pet.PetId = id;
            _rep.Update(pet);
        }
    }
}