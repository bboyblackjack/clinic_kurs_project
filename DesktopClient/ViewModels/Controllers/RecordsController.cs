using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.IO;
using System.Net;
using RestSharp;

namespace DesktopClient
{
    public static class RecordsController
    {        
        //ПОЛУЧИТЬ ВСЕ ЗАПИСИ
        public static dynamic GetAllRecords()
        {

            string url = "http://localhost:53444/api/record" + "?=param1=1&param2=1";
            WebRequest req = WebRequest.Create(url);
            WebResponse resp = req.GetResponse();
            Stream stream = resp.GetResponseStream();

            List<Record> records_result = new List<Record>();

            //parsing json
            using (var reader = new StreamReader(stream))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic records = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var rcd in records)
                {
                    Record record = new Record()
                    {
                        RecordId = rcd.RecordId,
                        UserId = rcd.UserId,
                        ServiceId = rcd.ServiceId,
                        CardId = rcd.CardId,
                        Date = rcd.Date,
                        TimeId = rcd.TimeId,
                    };

                    string url1 = "http://localhost:53444/api/record" + "/" + record.RecordId.ToString();
                    WebRequest req1 = WebRequest.Create(url1);
                    WebResponse resp1 = req1.GetResponse();
                    Stream stream1 = resp1.GetResponseStream();

                    //parsing json
                    using (var reader1 = new StreamReader(stream1))
                    {
                        var resultJSON1 = reader1.ReadToEnd();
                        dynamic rcdModels = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON1);

                        //добавляем услугу
                        Service service = new Service()
                        {
                            Name = rcdModels.Service.Name,
                        };
                        record.Service = service;

                        //добавляем время
                        Time time = new Time()
                        {
                            Interval = rcdModels.Time.Interval,
                        };
                        record.Time = time;

                        //добавляем врача
                        User user = new User()
                        {
                            FirstName = rcdModels.User.FirstName,
                            LastName = rcdModels.User.LastName,
                        };
                        record.User = user;
                    }                   
                    records_result.Add(record); ;
                }
                return records_result;
            }
        }

        //костыль
        public static int appId = 1;
        public static void GetCurrentApp(int app)
        {
            appId = app;
        }

        //НАЗНАЧИТЬ УСЛУГУ
        public static string PostRecord(int doctorId)
        {
            Application app = new Application();
            app = ApplicationController.GetApplicationById(appId);

            Card card = new Card();
            card = CardController.GetCardByPet(app.PetId);

            Record record = new Record();
            try
            {
                record.Date = app.Date;
                record.CardId = card.CardId;
                record.ServiceId = app.ServiceId;
                record.TimeId = app.TimeId;
                record.UserId = doctorId;
            }
            catch
            {

            }

            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/record/", Method.POST);
            request.AddJsonBody(record);

            var response = client.Execute(request);

            if (response.Content != "false")
            {
                var result = ApplicationController.Delete(app.ApplicationId);
                string resultJSON = response.Content;

                return resultJSON;
            }
            else
            {
                return null;
            }
        }

        //ОТМЕНИТЬ УСЛУГУ
        public static bool Delete(int id)
        {
            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/record/" + id.ToString(), Method.DELETE);
            request.AddJsonBody(id);

            var response = client.Execute(request);

            if (response.Content == "true")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
}
}
