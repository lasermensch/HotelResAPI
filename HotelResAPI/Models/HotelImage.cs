﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HotelResAPI.Models
{
    public class HotelImage
    {
        [Key]
        public Guid ImageId { get; set; }
        [ForeignKey("Hotel")]
        public Guid HotelId { get; set; }
        public string Uri { get; set; }

        //Navprop
        [JsonIgnore]
        public Hotel Hotel { get; set; }
    }
}
