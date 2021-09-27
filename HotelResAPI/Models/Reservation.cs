using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public byte Addons { get; set; }

        //Navprops
        public User User { get; set; }
        public Room Room { get; set; }
    }
}
