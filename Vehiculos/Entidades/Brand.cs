using System.ComponentModel.DataAnnotations;
namespace Vehiculos.Entidades
{
    public class Brand
    {
        //Primary  key- Identity(1,1)
        public int Id { get; set; }

        [Required]

        [StringLength(40)]
        public string Nombre { get; set; }
        //Relaciones
        public int VehicleId { get; set; }

        public Vehicle Vehicles { get; set; }

    }
}
 