using DataAccess;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace WebServer.Controllers
{
    public class CardController : ApiController
    {
        
        CardRepository _rep = new CardRepository();
        PetRepository _pet = new PetRepository();       

        DataContext db = new DataContext();

        // GET: api/card
        public IEnumerable<Card> Get()
        {
            return _rep.GetAll();
        }

        // GET: api/card/5
        public Card Get(int id)
        {
            var card = _rep.GetById(id);
            card.Pet = _pet.GetById(card.PetId);
            return card;
        }

        public Card Get(int id, int flag)
        {
            return _rep.GetByPet(id);
        }

        //POST: api/card
        public bool Post([FromBody] Card card)
        {
            int maxID = db.Cards.Max(c => c.CardId);
            card.CardId = ++maxID;
            try
            {
                _rep.Add(card);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //DELETE api/card
        public bool Delete(int id)
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

        //PUT api/card
        public bool Put([FromBody] Card card)
        {
            try
            {
                _rep.Update(card);             
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}