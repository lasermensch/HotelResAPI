using HotelResAPI.Controllers;
using HotelResAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HotelResDbContext context)
        {
            context.Database.EnsureCreated();

            if(!context.Hotels.Any())
            {
                Hotel[] hotels =
                {
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Royal", Adress="Main Street 123, SomeTown", PhoneNr="+2100855512345", Email="theroyal@hotels.test", WebPage="theroyalhotel.test"},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Mariner", Adress="Shore Street 4, SomeOtherTown", PhoneNr="+2100855512398", Email="themariner@hotels.test", WebPage="themarinerhotel.test"},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Plaza", Adress="Centre Street 1, ThatBigCity", PhoneNr="+422085555678", Email="theplaza@hotels.test", WebPage="theplazahotel.test"},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Proletarian", Adress="Peoples Street 95, MarxCity", PhoneNr="+378555849587", Email="theproletarian@hotels.test", WebPage="theproletarianhotel.test"},
                };
                foreach(Hotel h in hotels)
                {
                    context.Hotels.Add(h);
                }
                context.SaveChanges();
            }

            if(!context.Users.Any())
            {
                User[] users =
                {

                };
            }

            if(!context.Rooms.Any())
            {

            }

            if(!context.Reservations.Any())
            {

            }
        }
    }
}
