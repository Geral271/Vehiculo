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
    public class ProceduresCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class ProceduresController : Controller
        {
            private readonly ILogger<ProceduresController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public ProceduresController(ILogger<ProceduresController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<ProcedureDTO>>> Get()
            {
                var entidades = await context.Procedures.ToListAsync();

                return mapper.Map<List<ProcedureDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<ProcedureDTO>> Get(int id)
            {

                var Procedure = await context.Procedures.FirstOrDefaultAsync(x => x.Id == id);


                if (Procedure == null)
                {


                    return NotFound();
                }


                return mapper.Map<ProcedureDTO>(Procedure);

            }


            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] ProcedureCreacionDTO ProcedureCreacionDTO)
            //{

            //    var archivos = mapper.Map<Procedure>(ProcedureCreacionDTO);

            //    if (ProcedureCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, ProcedureCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}