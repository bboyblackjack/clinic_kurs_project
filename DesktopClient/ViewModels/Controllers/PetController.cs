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
    public static class PetController
    {
        //ПОЛУЧИТЬ ВСЕХ ЖИВОТНЫХ
        public static dynamic GetAllPets()
        {
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/pet");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<Pet> pets_result = new List<Pet>();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic pets = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var pt in pets)
                {
                        Pet pet = new Pet()
                        {
                            PetId = pt.PetId,
                            Name = pt.Name,

                        };
                        pets_result.Add(pet);                   
                }
            }
            return pets_result;
        }

        //ПОЛУЧИТЬ СВЯЗКУ КЛИЕНТ - ПИТОМЕЦ
        public static PetUserModel GetPetById(int id)
        {
            string url1 = "http://localhost:53444/api/pet" + "/" + id.ToString();
            WebRequest req1 = WebRequest.Create(url1);
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            PetUserModel pet_result = new PetUserModel();

            //parsing JSON
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic pet = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                pet_result = new PetUserModel()
                {
                    UserId = pet.UserId,
                    PetId = pet.PetId,
                };
            }
            return pet_result;
        }
    }
}
