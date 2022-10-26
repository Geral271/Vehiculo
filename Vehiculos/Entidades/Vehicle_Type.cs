using System.ComponentModel.DataAnnotations;
namespace Vehiculos.Entidades
{
    public class Vehicle_Type
    {
        //Primary  key- Identity(1,1)
        public int Id { get; set; }

        [Required]

        [StringLength(40)]
        public string Info { get; set; }
    }
}
