﻿using System.ComponentModel.DataAnnotations;
namespace Vehiculos.DTOs
{
    public class Vehicle_PhotoCreacionDTO
    {
        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
