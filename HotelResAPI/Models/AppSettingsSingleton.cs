using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class AppSettingsSingleton
    {
        public static AppSettingsSingleton Instance { get; set; } //Singleton.
        public string JwtSecret { get; set; }
        public string GoogleClientId { get; set; }
        public string GoogleClientSecret { get; set; }
        public string JwtEmailEncryption { get; set; }
    }
}
