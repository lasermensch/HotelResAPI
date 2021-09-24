using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class Hotel
    {
        [Key]
        [Required]
        public Guid HotelId { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNr { get; set; }
        public string WebPage { get; set; }

        //Navprops
        public ICollection<Room> Rooms { get; set; }
    }
}
