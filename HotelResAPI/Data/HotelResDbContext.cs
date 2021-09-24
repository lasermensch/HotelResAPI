using HotelResAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Data
{
    public class HotelResDbContext : DbContext
    {
        public HotelResDbContext(DbContextOptions<HotelResDbContext> options) : base(options)
        {

        }
        DbSet<Hotel> Hotels { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<Room> Rooms { get; set; }
        DbSet<User> Users { get; set; }
    }
}
