using System.ComponentModel.DataAnnotations;
namespace Vehiculos.DTOs
{
    public class Vehicle_PhotoDTO
    {
        public int Id { get; set; }

        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
