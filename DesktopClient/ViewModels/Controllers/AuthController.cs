using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using DataModel;

namespace DesktopClient
{
    public static class AuthController
    {
        //не факт, что понадобится, но на всякий случай
        public static int doctorId;

        //ПОЛУЧИТЬ ДОКТОРА ПО EMAIL
        public static bool GetByEmail(User user)
        {
            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/user/", Method.POST);
            request.AddJsonBody(user);

            var response = client.Execute(request);

            if (response.Content == "-1")
            {
                return false;
            }
            else
            {
                doctorId = Convert.ToInt32(response.Content);
                return true;
            }
        }
    }
}
