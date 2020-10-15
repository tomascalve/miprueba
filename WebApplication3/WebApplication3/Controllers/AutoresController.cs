using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using WebApplication3.Contexts;
using WebApplication3.Entities;

namespace WebApplication3.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class AutoresController: ControllerBase

    {
        private readonly ApplicationDbContext context;
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Autores>> Get()
        {
            return context.Autores.ToList();
        }
        [HttpGet("{id}", Name = "obtenerAutor")]
        public ActionResult<Autores> Get(int id )
        {
            var autores = context.Autores.FirstOrDefault(x => x.Id == id);
            if (autores == null)
            {
                return NotFound();
            }

            return autores;
        }
        [HttpPost]
        public ActionResult Post([FromBody] Autores autores)
        {
            context.Autores.Add(autores);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autores.Id }, autores );
        }
    }
}
