using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class PriceList
    {
        public Guid HotelId { get; set; } 
        public int PriceSingleRoom { get; set; }
        public int PriceDoubleRoom { get; set; }

        
    }
}
