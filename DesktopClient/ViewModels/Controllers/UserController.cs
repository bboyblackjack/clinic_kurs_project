using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.IO;
using System.Net;


namespace DesktopClient
{
    public static class UserController
    {
        //ПОЛУЧИТЬ ВСЕХ КЛИЕНТОВ
        public static dynamic GetAllUsers()
        {
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/user");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<User> users_result = new List<User>();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic users = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var usr in users)
                {
                    if (usr.RoleId == 1)
                    {
                        User user = new User()
                        {
                            UserId = usr.UserId,
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                        };
                        users_result.Add(user);
                    }
                }                
            }
            return users_result;
        }

        //ПОЛУЧИТЬ ВСЕХ ДОКТОРОВ
        public static dynamic GetAllDoctors()
        {
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/user");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<User> doctors_result = new List<User>();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic doctors = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var usr in doctors)
                {
                    if (usr.RoleId == 2)
                    {
                        User user = new User()
                        {
                            UserId = usr.UserId,
                            FirstName = usr.FirstName,
                            LastName = usr.LastName,
                        };
                        doctors_result.Add(user);
                    }
                }
            }
            return doctors_result;
        }
       
    }
}
