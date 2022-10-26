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
    public class BrandsCrontroller
    {
        [ApiController]
        [Route("api/vehiculos")]


        public class BrandsController : Controller
        {
            private readonly ILogger<BrandsController> logger;
            private readonly ApplicationDbContext context;
            private readonly IMapper mapper;
            private readonly IAlmacenadorArchivos almacenadorArchivos;
            private readonly string contenedor = "Files";

            public BrandsController(ILogger<BrandsController> logger, ApplicationDbContext context, IMapper mapper,
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

            public async Task<ActionResult<List<BrandDTO>>> Get()
            {
                var entidades = await context.Brands.ToListAsync();

                return mapper.Map<List<BrandDTO>>(entidades);

            }

            // Búsqueda por parámetro
            [HttpGet("{id:int}")]

            public async Task<ActionResult<BrandDTO>> Get(int id)
            {

                var Brand = await context.Brands.FirstOrDefaultAsync(x => x.Id == id);


                if (Brand == null)
                {


                    return NotFound();
                }


                return mapper.Map<BrandDTO>(Brand);

            }


            //[HttpPost]//401
            //          //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "Admin")]
            //public async Task<ActionResult> Post([FromForm] BrandCreacionDTO BrandCreacionDTO)
            //{

            //    var archivos = mapper.Map<Brand>(BrandCreacionDTO);

            //    if (BrandCreacionDTO.Foto != null)
            //    {

            //        archivos.Foto = await almacenadorArchivos.GuardarArchivo(contenedor, BrandCreacionDTO.Foto);

            //    }


            //    context.Add(archivos);
            //    await context.SaveChangesAsync();

            //    return NoContent();




            //}


        }
    }
}