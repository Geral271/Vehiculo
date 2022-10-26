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
    public class Document_TypesCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class Document_TypesController : Controller
        {
            private readonly ILogger<Document_TypesController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public Document_TypesController(ILogger<Document_TypesController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<Document_TypeDTO>>> Get()
            {
                var entidades = await context.Document_Types.ToListAsync();

                return mapper.Map<List<Document_TypeDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<Document_TypeDTO>> Get(int id)
            {

                var Document_Type = await context.Details.FirstOrDefaultAsync(x => x.Id == id);


                if (Document_Type == null)
                {


                    return NotFound();
                }


                return mapper.Map<Document_TypeDTO>(Document_Type);

            }


            //[HttpPost]//401
            //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] Document_TypeCreacionDTO Document_TypeCreacionDTO)
            //{

            //    var archivos = mapper.Map<Document_Type>(Document_TypeCreacionDTO);

            //    if (Document_TypeCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, Document_TypeCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}