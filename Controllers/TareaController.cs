using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using apitarea.dao;
using apitarea.Models;
using Microsoft.EntityFrameworkCore;

namespace apitarea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareaController : ControllerBase
    {
        private TareasContext dataContext;

       public TareaController(TareasContext context)
        {
            dataContext = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> Get()
        {           
            var respose = this.dataContext.Tareas.ToList();
            return respose;
        }

        [HttpPost]
        public IActionResult Post(Tarea request)
        {
            dataContext.Tareas.Add(request);
            dataContext.SaveChanges();
            return Ok("Se ha insertado");
        }

        [HttpGet()]
        [Route("[action]")]
        public ActionResult<IEnumerable<Tarea>> GetTarea()
        {
            string sql = "Exec sp_Tareas";
            var response = dataContext.Tareas.FromSqlRaw<Tarea>(sql).ToList();
                        
             if (response == null)
                return NotFound("No se encontro id= {id}");
            
            return response;
        }

        [HttpGet("{id}")]
        public ActionResult<Tarea> Get(int id)
        {
            var response = (from c in dataContext.Tareas where c.id == id 
                           select c).FirstOrDefault();
             
             if (response == null)
                return NotFound("No se encontro id= {id}");
            
            return response;
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Tarea request)
        {
            var response = dataContext.Tareas.Find(id); //(from c in empresaContext.Empresas
                           // where c.Id == id
                           // select c).FirstOrDefault();

            if (response == null)
                return NotFound("No se encontro id= {id}");

            response.Fecha = DateTime.Now;
            response.flagAtendido = request.flagAtendido;
            dataContext.SaveChanges();
            return Ok("Se modifico");
        }


          ~TareaController()
        {
            dataContext.Dispose();
        }

    }
}