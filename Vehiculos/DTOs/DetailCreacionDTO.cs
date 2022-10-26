using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class DetailCreacionDTO
    {
       
        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
