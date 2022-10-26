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
    public class Vehicle_PhotosCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class Vehicle_PhotosController : Controller
        {
            private readonly ILogger<Vehicle_PhotosController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public Vehicle_PhotosController(ILogger<Vehicle_PhotosController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<Vehicle_PhotoDTO>>> Get()
            {
                var entidades = await context.Vehicle_Photos.ToListAsync();

                return mapper.Map<List<Vehicle_PhotoDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<Vehicle_PhotoDTO>> Get(int id)
            {

                var Vehicle_Photo = await context.Vehicle_Photos.FirstOrDefaultAsync(x => x.Id == id);


                if (Vehicle_Photo == null)
                {


                    return NotFound();
                }


                return mapper.Map<Vehicle_PhotoDTO>(Vehicle_Photo);

            }


            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] Vehicle_PhotoCreacionDTO Vehicle_PhotoCreacionDTO)
            //{

            //    var archivos = mapper.Map<Vehicle_Photo>(Vehicle_PhotoCreacionDTO);

            //    if (Vehicle_PhotoCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, Vehicle_PhotoCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}
