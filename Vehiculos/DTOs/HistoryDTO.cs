using System.ComponentModel.DataAnnotations;

namespace Vehiculos.DTOs
{
    public class HistoryDTO
    {
        public int Id { get; set; }

        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
