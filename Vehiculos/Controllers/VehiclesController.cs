using AutoMapper;
using Vehiculos.Data;
using Vehiculos.DTOs;
using Vehiculos.Entidades;
using Vehiculos.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vehiculos.Controllers
{
    public class VehiclesCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class VehiclesController : Controller
        {
            private readonly ILogger<VehiclesController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public VehiclesController(ILogger<VehiclesController> logger, ApplicationDbContext context, IMapper mapper,
                 IAlmacenadorArchivos almacenadorArchivos)
            {
                this.logger = logger;
                this.context = context;
                this.mapper = mapper;
                this.almacenadorArchivos = almacenadorArchivos;

            }

            //Select * from actor
            [HttpGet]
            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]

            public async Task<ActionResult<List<VehicleDTO>>> Get()
            {
                var entidades = await context.Vehicles.ToListAsync();

                return mapper.Map<List<VehicleDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<VehicleDTO>> Get(int id)
            {

                var Vehicle = await context.Vehicles.FirstOrDefaultAsync(x => x.Id == id);


                if (Vehicle == null)
                {


                    return NotFound();
                }


                return mapper.Map<VehicleDTO>(Vehicle);

            }

            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] VehicleCreacionDTO VehicleCreacionDTO)
            //{

            //    var archivos = mapper.Map<Vehicle>(VehicleCreacionDTO);

            //    if (VehicleCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, VehicleCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}



        }
    }
}