using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataModel;

namespace DataAccess
{
    public class DbInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {         
            //------------роли----------------
            Role r1 = new Role { Name = "Пользователь" };
            context.Roles.Add(r1);
            Role r2 = new Role { Name = "Доктор" };
            context.Roles.Add(r2);

            //---------------пользователи--------
            User u1 = new User
            {
                FirstName = "Иван",
                MiddleName = "Юрьевич",
                LastName = "Михайлушкин",
                Email = "ivan@ya.ru",
                Login = "ivan",
                PhoneNumber = "89008008080",
                Password = "ivan",
                Role = r1
            };
            context.Users.Add(u1);
            User u2 = new User
            {
                FirstName = "Кирилл",
                MiddleName = "Геннадьевич",
                LastName = "Виноградов",
                Email = "kirill@ya.ru",
                Login = "kirill",
                PhoneNumber = "88005553535",
                Password = "kirill",
                Role = r1
            };
            context.Users.Add(u2);
            User u3 = new User
            {
                FirstName = "Олег",
                MiddleName = "Петрович",
                LastName = "Шумилин",
                Email = "oleg@ya.ru",
                Login = "oleg",
                PhoneNumber = "89008008888",
                Password = "oleg",
                Role = r2
            };
            context.Users.Add(u3);

            //-------------виды животных--------
            Kind k1 = new Kind { Name = "Птица" };
            context.Kinds.Add(k1);
            Kind k2 = new Kind { Name = "Собака" };
            context.Kinds.Add(k2);
            Kind k3 = new Kind { Name = "Кот" };
            context.Kinds.Add(k3);

            //-------------породы животных------------
            Breed b1 = new Breed { Name = "Петух" };
            context.Breeds.Add(b1);
            Breed b2 = new Breed { Name = "Бигль" };
            context.Breeds.Add(b2);
            Breed b3 = new Breed { Name = "Сфинкс" };

            //-------------окрас животных-----------
            Color c1 = new Color { Name = "Черный" };
            context.Colors.Add(c1);
            Color c2 = new Color { Name = "Бело-рыже-черный" };
            context.Colors.Add(c2);
            Color c3 = new Color { Name = "Серый" };
            context.Colors.Add(c3);

            //--------------интервалы времени----------
            Time t1 = new Time { Interval = "8:00 - 9:00" };
            context.Times.Add(t1);
            Time t2 = new Time { Interval = "9:00 - 10:00" };
            context.Times.Add(t2);
            Time t3 = new Time { Interval = "10:00 - 11:00" };
            context.Times.Add(t3);
            Time t4 = new Time { Interval = "11:00 - 12:00" };
            context.Times.Add(t4);
            Time t5 = new Time { Interval = "12:00 - 13:00" };
            context.Times.Add(t5);
            Time t6 = new Time { Interval = "13:00 - 14:00" };
            context.Times.Add(t6);
            Time t7 = new Time { Interval = "14:00 - 15:00" };
            context.Times.Add(t7);
            Time t8 = new Time { Interval = "15:00 - 16:00" };
            context.Times.Add(t8);
            Time t9 = new Time { Interval = "16:00 - 17:00" };
            context.Times.Add(t9);
            Time t10 = new Time { Interval = "17:00 - 18:00" };
            context.Times.Add(t10);

            //--------------типы услуг-----------------------
            TypeOfService ts1 = new TypeOfService { Name = "Клинический осмотр" };
            context.TypesOfServices.Add(ts1);
            TypeOfService ts2 = new TypeOfService { Name = "Вакцинация" };
            context.TypesOfServices.Add(ts2);
            TypeOfService ts3 = new TypeOfService { Name = "Блокада" };
            context.TypesOfServices.Add(ts3);
            TypeOfService ts4 = new TypeOfService { Name = "Купирование" };
            context.TypesOfServices.Add(ts4);
            TypeOfService ts5 = new TypeOfService { Name = "Обрезка" };
            context.TypesOfServices.Add(ts5);

            //---------------------услуги-----------------------------
            Service ser1 = new Service { Name = "Обрезка рогов", TypeOfService = ts5, Price = 500 };
            context.Services.Add(ser1);
            Service ser2 = new Service { Name = "Обрезка когтей", TypeOfService = ts5, Price = 500 };
            context.Services.Add(ser2);
            Service ser3 = new Service { Name = "Обрезка клюва", TypeOfService = ts5, Price = 500 };
            context.Services.Add(ser3);
            Service ser4 = new Service { Name = "Вакцинация от бешенства", TypeOfService = ts2, Price = 300 };
            context.Services.Add(ser4);
            Service ser5 = new Service { Name = "Вакцинация от чумы", TypeOfService = ts2, Price = 400 };
            context.Services.Add(ser5);


            //-----------------животные------------------
            Pet p1 = new Pet { Name = "Шарик", Birthday = new DateTime(2015, 01, 30), User = u1, Kind = k3, Breed = b3, Color = c3 };
            context.Pets.Add(p1);
            Pet p2 = new Pet { Name = "Бобик", Birthday = new DateTime(2016, 11, 10), User = u2, Kind = k1, Breed = b1, Color = c1 };
            context.Pets.Add(p2);
            Pet p3 = new Pet { Name = "Василий", Birthday = new DateTime(2014, 05, 04), User = u2, Kind = k2, Breed = b2, Color = c2 };
            context.Pets.Add(p3);

            //---------------карточки животных-------------------------
            Card card1 = new Card { Pet = p1, Height = 20, Weight = 10 };
            context.Cards.Add(card1);
            Card card2 = new Card { Pet = p2, Height = 25, Weight = 15 };
            context.Cards.Add(card2);

            //---------------------заявки-------------------
            Application app1 = new Application 
            { 
                Date = new DateTime(2017, 03, 16), 
                User = u1, 
                Pet = p1, 
                Time = t6, 
                Service = ser5 
            };
            context.Applications.Add(app1);
            Application app2 = new Application 
            { 
                Date = new DateTime(2017, 03, 18), 
                User = u2, 
                Pet = p2, 
                Time = t5, 
                Service = ser1
            };
            context.Applications.Add(app2);

            //------------записи-----------------
            Record rec1 = new Record
            {
                Date = new DateTime(2017, 03, 16),
                User = u3,
                Time = t6,
                Service = ser5,
                Card = card1
            };
            context.Records.Add(rec1);

            base.Seed(context);
        }
    }
}
