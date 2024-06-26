using Api_Prueba.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Prueba.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class HelloWorldController: ControllerBase
    {
        IHelloworldService helloworldService;

        ApplicationDbcontex dbcontex;

        public HelloWorldController(IHelloworldService helloworld, ApplicationDbcontex db)
        {
            helloworldService = helloworld;
            dbcontex = db;
        }

        [HttpGet]    
        public IActionResult Get()
        {
            return Ok(helloworldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDataBase()
        {
            dbcontex.Database.EnsureCreated();

            return Ok();
        }
    }
}