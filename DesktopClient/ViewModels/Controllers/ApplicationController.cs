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
    public static class ApplicationController
    {
        //ПОЛУЧИТЬ ВСЕ ЗАЯВКИ
        public static dynamic GetAllApplications()
        {
            //------------вытаскиваем заявки--------------------
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/application");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<Application> applications_result = new List<Application>();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic applications = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var app in applications)
                {
                    Application application = new Application()
                    {
                        ApplicationId = app.ApplicationId,
                        Date = app.Date,
                        UserId = app.UserId,
                        PetId = app.PetId,
                        TimeId = app.TimeId,
                        ServiceId = app.ServiceId,
                    };

                    string url2 = "http://localhost:53444/api/application" + "/" + application.ApplicationId.ToString();
                    WebRequest req2 = WebRequest.Create(url2);
                    WebResponse resp2 = req2.GetResponse();
                    Stream stream2 = resp2.GetResponseStream();

                    //parsing json
                    using (var reader2 = new StreamReader(stream2))
                    {
                        var resultJSON1 = reader2.ReadToEnd();
                        dynamic appModels = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON1);

                        //добавляем пользователя
                        User user = new User()
                        {
                            FirstName = appModels.User.FirstName,
                            LastName = appModels.User.LastName,
                        };
                        application.User = user;

                        //добавляем питомца
                        Pet pet = new Pet()
                        {
                            Name = appModels.Pet.Name,
                        };
                        application.Pet = pet;

                        //добавляем услугу
                        Service service = new Service()
                        {
                            Name = appModels.Service.Name,
                        };
                        application.Service = service;

                        //добавляем время
                        Time time = new Time()
                        {
                            Interval = appModels.Time.Interval,
                        };
                        application.Time = time;
                    }

                    applications_result.Add(application); ;
                }
            }
            return applications_result;
        }

        //ПОЛУЧИТЬ ЗАЯВКУ ПО ID
        public static Application GetApplicationById(int id)
        {
            string url1 = "http://localhost:53444/api/application" + "/" + id.ToString();
            WebRequest req1 = WebRequest.Create(url1);
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            Application application = new Application();

            //parsing JSON
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic app = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                application = new Application()
                {
                    ApplicationId = app.ApplicationId,
                    TimeId = app.TimeId,
                    ServiceId = app.ServiceId,
                    Date = app.Date,
                    PetId = app.PetId,
                };
            }
            return application;
        }

        //УДАЛИТЬ ЗАЯВКУ
        public static bool Delete(int id)
        {
            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/application/" + id.ToString(), Method.DELETE);
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
