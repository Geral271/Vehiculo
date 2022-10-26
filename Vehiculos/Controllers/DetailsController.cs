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
    public class DetailsCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class DetailsController : Controller
        {
            private readonly ILogger<DetailsController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public DetailsController(ILogger<DetailsController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<DetailDTO>>> Get()
            {
                var entidades = await context.Details.ToListAsync();

                return mapper.Map<List<DetailDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<DetailDTO>> Get(int id)
            {

                var Detail = await context.Details.FirstOrDefaultAsync(x => x.Id == id);


                if (Detail == null)
                {


                    return NotFound();
                }


                return mapper.Map<DetailDTO>(Detail);

            }


            //[HttpPost]//401
            //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] DetailCreacionDTO DetailCreacionDTO)
            //{

            //    var archivos = mapper.Map<Detail>(DetailCreacionDTO);

            //    if (DetailCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, DetailCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}