﻿using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class HistoryCreacionDTO
    {
       
        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
