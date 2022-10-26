using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }

        [Required]

        [StringLength(40)]
        public string Nombre { get; set; }
    }
}
