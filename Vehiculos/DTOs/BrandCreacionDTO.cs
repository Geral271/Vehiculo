using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class BrandCreacionDTO
    {
        [Required]

        [StringLength(50)]
        public string Nombre { get; set; }

    }
}
