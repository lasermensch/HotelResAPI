using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNr { get; set; }
        [Required]
        public string Password { get; set; }
        
        public string Salt { get; set; }

        public ICollection<Reservation> Reservations { get; set; } //NavProp
    }
}
