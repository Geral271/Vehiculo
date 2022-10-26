using System.ComponentModel.DataAnnotations;
namespace Vehiculos.DTOs
{
    public class Vehicle_TypeCreacionDTO
    {
        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
