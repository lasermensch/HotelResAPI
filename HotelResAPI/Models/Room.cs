using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class Room
    {
        [Key]
        public Guid RoomId { get; set; }
        [ForeignKey("Hotel")]
        public Guid HotelId { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        public int Price { get; set; }
        

        //Navprops
        public Hotel Hotel { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        
    }
}
