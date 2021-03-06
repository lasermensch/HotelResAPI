using HotelResAPI.Controllers;
using HotelResAPI.Models;
using HotelResAPI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace HotelResAPI.Data
{
    public static class DbInitializer
    {

        public static void Initialize(HotelResDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Hotels.Any())
            {
                Hotel[] hotels =
                {
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Royal", Adress="Main Street 123, SomeTown", PhoneNr="+2100855512345", Email="theroyal@hotels.test", WebPage="theroyalhotel.test", NrOfVotes=498, Rating=4.4, PriceAllInclusive=400, PriceBreakfast=150, PriceTransport=50, PricePool=100, PriceDoubleRoom=5600, PriceSingleRoom=4500, PriceSuite=7000},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Mariner", Adress="Shore Street 4, SomeOtherTown", PhoneNr="+2100855512398", Email="themariner@hotels.test", WebPage="themarinerhotel.test", NrOfVotes=70, Rating=5.0, PriceAllInclusive=340, PriceBreakfast=150, PriceTransport=35, PricePool=95, PriceDoubleRoom=5200, PriceSingleRoom=4450, PriceSuite=6500},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Plaza", Adress="Centre Street 1, ThatBigCity", PhoneNr="+422085555678", Email="theplaza@hotels.test", WebPage="theplazahotel.test", NrOfVotes=34, Rating=4.34, PriceAllInclusive=590, PriceBreakfast=169, PriceTransport=45, PricePool=119, PriceDoubleRoom=5790, PriceSingleRoom=4990, PriceSuite=7590},
                    new Hotel {HotelId = Guid.NewGuid(), HotelName="The Proletarian", Adress="Peoples Street 95, MarxCity", PhoneNr="+378555849587", Email="theproletarian@hotels.test", WebPage="theproletarianhotel.test", NrOfVotes=67, Rating=2.7, PriceAllInclusive=300, PriceBreakfast=99, PriceTransport=49, PricePool=49, PriceDoubleRoom=3000, PriceSingleRoom=1990, PriceSuite=4000},
                };

                HotelImage[] hotelImages =
                {
                    new HotelImage { HotelId = hotels[0].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2014/07/10/17/17/hotel-389256_960_720.jpg" },
                    new HotelImage { HotelId = hotels[0].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2015/09/28/21/32/the-palm-962785_960_720.jpg" },
                    new HotelImage { HotelId = hotels[0].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2015/09/21/09/53/villa-cortine-palace-949547_960_720.jpg" },
                    new HotelImage { HotelId = hotels[0].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2018/10/01/00/52/roof-top-pool-3715118_960_720.jpg" },
                    new HotelImage { HotelId = hotels[1].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2018/03/06/19/40/pool-3204359_960_720.jpg" },
                    new HotelImage { HotelId = hotels[1].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2015/03/09/18/34/beach-666122_960_720.jpg" },
                    new HotelImage { HotelId = hotels[1].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2018/08/14/11/03/acapulco-3605307_960_720.jpg" },
                    new HotelImage { HotelId = hotels[1].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2020/03/09/21/43/holiday-4917217_960_720.jpg" },
                    new HotelImage { HotelId = hotels[2].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2016/10/13/09/10/swimming-pool-1737173_960_720.jpg" },
                    new HotelImage { HotelId = hotels[2].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2019/09/24/11/35/punta-bianca-beach-4501076_960_720.jpg" },
                    new HotelImage { HotelId = hotels[2].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2016/12/27/09/24/grand-canal-1933559_960_720.jpg" },
                    new HotelImage { HotelId = hotels[2].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2014/03/03/16/12/village-279013_960_720.jpg" },
                    new HotelImage { HotelId = hotels[3].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2019/10/08/04/16/dragon-palace-hotel-4534092_960_720.jpg" },
                    new HotelImage { HotelId = hotels[3].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2017/04/15/17/44/border-2232996_960_720.jpg" },
                    new HotelImage { HotelId = hotels[3].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2018/04/18/01/51/architecture-3329296_960_720.jpg" },
                    new HotelImage { HotelId = hotels[3].HotelId, ImageId= Guid.NewGuid(), Uri="https://cdn.pixabay.com/photo/2018/04/17/02/57/city-3326425_960_720.jpg" },

                };

                foreach (Hotel h in hotels)
                {
                    h.Images = new List<HotelImage>(hotelImages.Where(hi => hi.HotelId == h.HotelId));

                    context.Hotels.Add(h);
                }
                context.SaveChanges();
            }

            if (!context.Users.Any())
            {
                User[] users =
                {
                    new User{UserId = Guid.NewGuid(), Adress="123 First Street, Hometown", FirstName="Erik", LastName="Sundberg", Email="sten.erik.sundberg@gmail.com", Salt="6*TaXSUa?1JadPez", Password=SecurityService.Hasher("SuperHemligtLösen", "6*TaXSUa?1JadPez"), PhoneNr="0762336181"},
                    new User{UserId = Guid.NewGuid(), Adress="1 Corporate Road, HQCity", FirstName="Admin", LastName="Adminsson", Email="admin@thiscorporation.test", Salt="Q2t6f7*x9#7k1aM1", Password=SecurityService.Hasher("AdminGodMode", "Q2t6f7*x9#7k1aM1"), PhoneNr="0123145135"},
                    new User{UserId = Guid.NewGuid(), Adress="4 Second Street, Hometown", FirstName="Anders", LastName="Anderssom", Email="snafu@mail.test", Salt="$wVHmNEFh2akTrJx", Password=SecurityService.Hasher("SäkertLösen", "$wVHmNEFh2akTrJx"), PhoneNr="1765876587"},
                    new User{UserId = Guid.NewGuid(), Adress="5 Some Road, Sometown", FirstName="Per", LastName="Persson", Email="fubar@mail.test", Salt="xcBFR12qd!h&$?1@", Password=SecurityService.Hasher("WhatEver", "xcBFR12qd!h&$?1@"), PhoneNr="3475938745"},
                    new User{UserId = Guid.NewGuid(), Adress="5 Some Road, Sometown", FirstName="Lars", LastName="Larsson", Email="somename@mail.test", Salt="xcBFR12qd!h&$?1@", Password=SecurityService.Hasher("NågotLösen2", "xcBFR12qd!h&$?1@"), PhoneNr="3475938745"},
                };

                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();
            }

            if (!context.Rooms.Any())
            {
                Room[] rooms =
                {
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=2},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).HotelId, Size=2},

                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).HotelId, Size=2},
                    
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).HotelId, Size=2},
                    
                    
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=0},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=1},
                    new Room{RoomId=Guid.NewGuid(), HotelId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).HotelId, Size=2},
                };

                foreach (Room r in rooms)
                {
                    context.Rooms.Add(r);
                }
                context.SaveChanges();
            }

            if (!context.Reservations.Any())
            {
                Reservation[] reservations =
                {
                    
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-11"), EndDate=DateTime.Parse("2021-10-18"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).Rooms.ElementAt(2).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(2).UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false},
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-11"), EndDate=DateTime.Parse("2021-10-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).Rooms.ElementAt(2).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(1).UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-11-11"), EndDate=DateTime.Parse("2021-11-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).Rooms.ElementAt(2).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(1).UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-12-11"), EndDate=DateTime.Parse("2021-12-18"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).Rooms.ElementAt(2).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(0).UserId, IncludeAll=true, IncludeBreakfast=true, IncludePool=false, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-18"), EndDate=DateTime.Parse("2021-10-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).Rooms.ElementAt(1).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(2).UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-11"), EndDate=DateTime.Parse("2021-10-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(2).Rooms.ElementAt(0).RoomId, UserId=context.Users.AsEnumerable<User>().ElementAt(0).UserId, IncludeAll=false, IncludeBreakfast=false, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-18"), EndDate=DateTime.Parse("2021-10-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(3).Rooms.ElementAt(0).RoomId, UserId=context.Users.AsEnumerable<User>().FirstOrDefault(u=>u.Email == "sten.erik.sundberg@gmail.com").UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-25"), EndDate=DateTime.Parse("2021-11-08"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).Rooms.ElementAt(1).RoomId, UserId=context.Users.AsEnumerable<User>().FirstOrDefault(u=>u.Email == "sten.erik.sundberg@gmail.com").UserId, IncludeAll=false, IncludeBreakfast=false, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-10-25"), EndDate=DateTime.Parse("2021-11-08"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(1).Rooms.Last().RoomId, UserId=context.Users.AsEnumerable<User>().FirstOrDefault(u=>u.Email == "sten.erik.sundberg@gmail.com").UserId, IncludeAll=true, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    new Reservation{ReservationId=Guid.NewGuid(), StartDate=DateTime.Parse("2021-12-11"), EndDate=DateTime.Parse("2021-12-25"), RoomId=context.Hotels.AsEnumerable<Hotel>().ElementAt(0).Rooms.ElementAt(3).RoomId, UserId=context.Users.AsEnumerable<User>().FirstOrDefault(u=>u.Email == "sten.erik.sundberg@gmail.com").UserId, IncludeAll=false, IncludeBreakfast=true, IncludePool=true, IncludeTransport=false },
                    
                };
                foreach (Reservation r in reservations)
                {
                    r.Room = context.Rooms.First(room => room.RoomId == r.RoomId);
                    r.Room.Hotel = context.Hotels.First(hotel => hotel.HotelId == r.Room.HotelId);
                    r.TotalAmount = CalculateTotAm(r);
                    context.Reservations.Add(r);
                }
                context.SaveChanges();
            }
        }
        private static int CalculateTotAm(Reservation r)
        {
            int totam = 0;
            if (r.Room.Size == 0)
                totam += r.Room.Hotel.PriceSingleRoom;
            else if (r.Room.Size == 1)
                totam += r.Room.Hotel.PriceDoubleRoom;
            else if (r.Room.Size == 2)
                totam += r.Room.Hotel.PriceSuite;

            if (r.IncludeAll)
                totam += r.Room.Hotel.PriceAllInclusive;
            if (r.IncludeBreakfast)
                totam += r.Room.Hotel.PriceBreakfast;
            if (r.IncludeTransport)
                totam += r.Room.Hotel.PriceTransport;
            if (r.IncludePool)
                totam += r.Room.Hotel.PricePool;

            return totam;
        }
    }
    
}
