using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class ProcedureCreacionDTO
    {
        

        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
