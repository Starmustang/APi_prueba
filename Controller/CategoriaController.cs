using Api_Prueba.Models;
using Api_Prueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba.Controller
{
    [Route("api/[controller]")]
    public class CategoriaController:ControllerBase
    {
        protected readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService service)
        {
            _categoriaService = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoriaService.Get());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            _categoriaService.Save(categoria);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            _categoriaService.Update(id,categoria);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoriaService.Delete(id);
            return Ok();
        }
    }
}