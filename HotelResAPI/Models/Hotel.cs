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
        [Required]
        public double Rating { get; set; } = 0;
        [Required]
        public int NrOfVotes { get; set; } = 0;
        [Required]
        public int PriceSingleRoom { get; set; }
        [Required]
        public int PriceDoubleRoom { get; set; }
        [Required]
        public int PriceSuite { get; set; }
        [Required]
        public int PriceTransport { get; set; }
        [Required]
        public int PriceBreakfast { get; set; }
        [Required]
        public int PricePool { get; set; }
        [Required]
        public int PriceAllInclusive { get; set; }


        //Navprops
        public ICollection<Room> Rooms { get; set; }
        public ICollection<HotelImage> Images { get; set; }
    }
}
