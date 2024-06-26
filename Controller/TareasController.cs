using Api_Prueba.Models;
using Api_Prueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba.Controller
{
    [Route("api/[controller]")]
    public class TareasController:ControllerBase
    {
       protected readonly ITareaService _tareaService;

       public TareasController(ITareaService service)
       {
          _tareaService = service;
       }

       [HttpGet]
       public IActionResult Get()
       {
            return Ok(_tareaService.Get());
       }
        [HttpPost]
        public IActionResult Post([FromBody] Tarea tarea)
        {
            _tareaService.Save(tarea);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] Tarea tarea)
        {
            _tareaService.Update(id,tarea);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _tareaService.Delete(id);
            return Ok();
        }

    }
}