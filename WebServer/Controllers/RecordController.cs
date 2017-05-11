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