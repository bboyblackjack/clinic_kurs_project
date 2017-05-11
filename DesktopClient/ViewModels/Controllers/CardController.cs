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
    public static class CardController
    {
        //ПОЛУЧИТЬ ВСЕ КАРТОЧКИ
        public static dynamic GetAllCards()
        {
            //------------вытаскиваем саму карточку--------------------
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/card");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<Card> cards_result = new List<Card>();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic cards = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var crd in cards)
                {
                    Card card = new Card()
                    {
                        CardId = crd.CardId,
                        PetId = crd.PetId,
                    };

                     string url2 = "http://localhost:53444/api/card" + "/" + card.CardId.ToString();
                    WebRequest req2 = WebRequest.Create(url2);
                    WebResponse resp2 = req2.GetResponse();
                    Stream stream2 = resp2.GetResponseStream();

                    //parsing json
                    using (var reader2 = new StreamReader(stream2))
                    {
                        var resultJSON1 = reader2.ReadToEnd();
                        dynamic cardModels = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON1);

                        //добавляем питомца
                        Pet pet = new Pet()
                        {
                            Name = cardModels.Pet.Name,
                        };
                        card.Pet = pet;
                    }

                    string url3 = "http://localhost:53444/api/pet" + "/" + card.PetId.ToString();
                    WebRequest req3 = WebRequest.Create(url3);
                    WebResponse resp3 = req3.GetResponse();
                    Stream stream3 = resp3.GetResponseStream();

                    //parsing json
                    using (var reader3 = new StreamReader(stream3))
                    {
                        var resultJSON2 = reader3.ReadToEnd();
                        dynamic petsModels = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON2);

                        //добавляем пользователя
                        User user = new User()
                        {
                            FirstName = petsModels.User.FirstName,
                            LastName = petsModels.User.LastName,
                        };
                        card.Pet.User = user;
                    }

                    cards_result.Add(card); ;
                }
            }
            return cards_result;
        }

        //ПОЛУЧИТЬ КАРТОЧКУ ПО ID
        public static Card GetCardById(int id)
        {
            //------------вытаскиваем саму карточку--------------------
            string url1 = "http://localhost:53444/api/card" + "/" + id.ToString();
            WebRequest req1 = WebRequest.Create(url1);
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            Card card_result = new Card();

            //parsing JSON
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic card = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                card_result = new Card()
                {
                    CardId = card.CardId,
                    Height = card.Height,
                    Weight = card.Weight,
                    PetId = card.PetId,                
                };

                //добавляем питомца
                Pet pet = new Pet()
                {
                    Name = card.Pet.Name,
                    Birthday = card.Pet.Birthday,
                    KindId = card.Pet.KindId,
                    UserId = card.Pet.UserId,
                    ColorId = card.Pet.ColorId,
                    BreedId = card.Pet.BreedId,
                };
                card_result.Pet = pet;

                string url2 = "http://localhost:53444/api/pet" + "/" + card_result.PetId.ToString();
                WebRequest req2 = WebRequest.Create(url2);
                WebResponse resp2 = req2.GetResponse();
                Stream stream2 = resp2.GetResponseStream();

                //parsing json
                using (var reader2 = new StreamReader(stream2))
                {
                    var resultJSON1 = reader2.ReadToEnd();
                    dynamic petModels = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON1);

                    //добавляем пользователя
                    User user = new User()
                    {
                        FirstName = petModels.User.FirstName,
                        LastName = petModels.User.LastName,
                    };
                    card_result.Pet.User = user;

                    //добавляем вид
                    Kind kind = new Kind()
                    {
                        Name = petModels.Kind.Name,
                    };
                    card_result.Pet.Kind = kind;

                    //добавляем породу
                    Breed breed = new Breed()
                    {
                        Name = petModels.Breed.Name,
                    };
                    card_result.Pet.Breed = breed;

                    //добавляем цвет
                    Color color = new Color()
                    {
                        Name = petModels.Color.Name,
                    };
                    card_result.Pet.Color = color;
                }
            }
            return card_result;
        }

        //ДОБАВИТЬ КАРТОЧКУ
        public static string PostCard(Card card)
        {
            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/card/", Method.POST);
            request.AddJsonBody(card);

            var response = client.Execute(request);

            if (response.Content != "null")
            {
                string resultJSON = response.Content;

                return resultJSON;
            }
            else
            {
                return null;
            }
        }

        //ПОЛУЧИТЬ КАРТОЧКУ ПО ЖИВОТНОМУ
        public static Card GetCardByPet(int PetId)
        {
            //------------вытаскиваем саму карточку--------------------
            WebRequest req1 = WebRequest.Create("http://localhost:53444/api/card");
            WebResponse resp1 = req1.GetResponse();
            Stream stream1 = resp1.GetResponseStream();

            List<Card> cards_list = new List<Card>();
            Card card_result = new Card();

            //parsing json
            using (var reader = new StreamReader(stream1))
            {
                var resultJSON = reader.ReadToEnd();
                dynamic cards = Newtonsoft.Json.JsonConvert.DeserializeObject(resultJSON);

                foreach (var crd in cards)
                {
                    Card card = new Card()
                    {
                        CardId = crd.CardId,
                        PetId = crd.PetId,
                    };
                    if (card.PetId == PetId)
                        card_result = card;
                };
            }
            return card_result;
        }


        //УДАЛИТЬ КАРТОЧКУ
        public static bool Delete(int id)
        {
            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/card/" + id.ToString(), Method.DELETE);
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

        //костыль
        public static int cardId = 1;
        public static void GetCurrentCard(int card)
        {
            cardId = card;
        }

        //ИЗМЕНИТЬ КАРТОЧКУ
        public static bool Edit(double _height, double _weight)
        {
            Card card = new Card();
            card = GetCardById(cardId);
            if (_height != 0)
                card.Height = _height;
            if (_weight != 0)
                card.Weight = _weight;

            var client = new RestClient("http://localhost:53444/");
            var request = new RestRequest("api/card/", Method.PUT);
            request.AddJsonBody(card);

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
