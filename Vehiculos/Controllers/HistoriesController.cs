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
    public class HistoriesCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class HistoriesController : Controller
        {
            private readonly ILogger<HistoriesController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public HistoriesController(ILogger<HistoriesController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<HistoryDTO>>> Get()
            {
                var entidades = await context.Histories.ToListAsync();

                return mapper.Map<List<HistoryDTO>>(entidades);




            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<HistoryDTO>> Get(int id)
            {

                var History = await context.Details.FirstOrDefaultAsync(x => x.Id == id);


                if (History == null)
                {


                    return NotFound();
                }


                return mapper.Map<HistoryDTO>(History);

            }


            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] HistoryCreacionDTO HistoryCreacionDTO)
            //{

            //    var archivos = mapper.Map<History>(HistoryCreacionDTO);

            //    if (HistoryCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor,HistoryCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}