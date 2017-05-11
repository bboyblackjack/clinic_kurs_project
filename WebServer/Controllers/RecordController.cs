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
    public class RecordController : ApiController
    {
        RecordRepository _rep = new RecordRepository();
        UserRepository _user = new UserRepository();
        TimeRepository _time = new TimeRepository();
        ServiceRepository _service = new ServiceRepository();
        CardRepository _card = new CardRepository();
        PetRepository _pet = new PetRepository();
        DataContext db = new DataContext();

        // GET: api/Record
        public IEnumerable<Record> Get()
        {
            return _rep.GetAll();
        }

        public IEnumerable<Record> Get(int flag1, int flag2)
        {
            IEnumerable<Record> records = _rep.GetAll();
            foreach (var rcd in records)
            {
                rcd.User = _user.GetById(rcd.UserId);
                rcd.Time = _time.GetById(rcd.TimeId);
                rcd.Service = _service.GetById(rcd.ServiceId);
                rcd.Card = _card.GetById(rcd.CardId);
            }
            return records;
        }

        // GET api/Record/5
        public Record Get(int id)
        {
            var record = _rep.GetById(id);
            record.Card = _card.GetById(record.CardId);
            record.Service = _service.GetById(record.ServiceId);
            record.Time = _time.GetById(record.TimeId);
            record.User = _user.GetById(record.UserId);
            return record;
        }

        //POST: api/record
        public bool Post([FromBody] Record record)
        {
            int maxID = db.Records.Max(r => r.RecordId);
            record.RecordId = ++maxID;
            try
            {
                _rep.Add(record);

                record.User = _user.GetById(record.UserId);
                record.Card = _card.GetById(record.CardId);
                record.Card.Pet = _pet.GetById(record.Card.PetId);
                record.Card.Pet.User = _user.GetById(record.Card.Pet.UserId);
                record.Service = _service.GetById(record.ServiceId);
                record.Time = _time.GetById(record.TimeId);
                //рассылка по почте
                EmailNotifier.IEmailNotifier mail = new EmailNotifier.MailRuNotifier("3208607970@mail.ru", "3208607970@mail.ru");
                mail.Send("Заявка одобрена!", "Заявка номер " + record.RecordId + " для вашего питомца " + record.Card.Pet.Name + " одобрена.\n" +
                "Услуга " + record.Service.Name + ".\n" + "Цена услуги " + record.Service.Price +
                " рублей.\n" + "Время записи " + record.Time.Interval + ".", record.Card.Pet.User.Email.ToString());

                return true; 
            }
            catch
            {
                return false;
            }
        }

        //DELETE api/record
        public bool Delete([FromBody] int id)
        {
            try
            {
                Record record = new Record();
                record = _rep.GetById(id);
                record.User = _user.GetById(record.UserId);
                record.Card = _card.GetById(record.CardId);
                record.Card.Pet = _pet.GetById(record.Card.PetId);
                record.Card.Pet.User = _user.GetById(record.Card.Pet.UserId);

                //рассылка по почте
                EmailNotifier.IEmailNotifier mail = new EmailNotifier.MailRuNotifier("3208607970@mail.ru", "3208607970@mail.ru");
                mail.Send("Заявка отменена!", "Заявка номер " + record.RecordId + " для вашего питомца " + record.Card.Pet.Name + " отменена.", record.Card.Pet.User.Email.ToString());

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