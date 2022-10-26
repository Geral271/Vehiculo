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
    public class Vehicle_TypesCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class Vehicle_TypesController : Controller
        {
            private readonly ILogger<Vehicle_TypesController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public Vehicle_TypesController(ILogger<Vehicle_TypesController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<Vehicle_TypeDTO>>> Get()
            {
                var entidades = await context.Vehicle_Types.ToListAsync();

                return mapper.Map<List<Vehicle_TypeDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<Vehicle_TypeDTO>> Get(int id)
            {

                var Vehicle_Type = await context.Vehicle_Types.FirstOrDefaultAsync(x => x.Id == id);


                if (Vehicle_Type == null)
                {


                    return NotFound();
                }


                return mapper.Map<Vehicle_TypeDTO>(Vehicle_Type);

            }


            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] Vehicle_TypeCreacionDTO Vehicle_TypeCreacionDTO)
            //{

            //    var archivos = mapper.Map<Vehicle_Type>(Vehicle_TypeCreacionDTO);

            //    if (Vehicle_TypeCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, Vehicle_TypeCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}
