using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataModel;

namespace DataAccess
{
    public class CardRepository: IRepository<Card>
    {
        DataContext db;

        public CardRepository()
        {
            this.db = new DataContext();
        }

        public List<Card> GetAll()
        {
            List<Card> allCards = db.Set<Card>().ToList();

            return allCards;
        }

        public Card GetById(int id)
        {
            var card = db.Cards.Find(id);

            return card;
        }

        public Card GetByPet(int PetId)
        {
            var card = db.Cards.SingleOrDefault(crd => crd.PetId == PetId);
            return card;
        }

        public void Remove(int id)
        {
            var card = db.Cards.Find(id);

            db.Cards.Remove(card);
            db.SaveChanges();
        }

        public void Update(Card card)
        {
            Card entity = db.Cards.Find(card.CardId);
            entity.Height = card.Height;
            entity.Weight = card.Weight;
            db.SaveChanges();
        }

        public void Add(Card card)
        {
            db.Cards.Add(card);
            db.SaveChanges();
        }
    }
}
