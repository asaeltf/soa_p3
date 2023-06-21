using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Service.IServices;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace soa_p2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonasController : Controller
    {
        private readonly IPersona _persona;

        public PersonasController(IPersona persona)
        {
            _persona = persona;
        }

        //Get personas
        [HttpGet]
        public IActionResult Index()
        {
            //ServiceReference1.ServiceClient client = new ServiceReference1.ServiceClient();
            //var result = client.ObtenerEmpleadosAsync().Result;
            return Ok(_persona.ObtenerEmpleados());
        }

        //Get empleados
        /*[HttpGet]
        public IActionResult Index()
        {
            return Ok(_persona.ObtenerEmpleados());
        }*/

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostEmpleados([FromBody] PostEmpleadoRequest request)
        {
            return Ok(_persona.RegistrarEmpleado(request));
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarEmpleado(int id)
        {
            var response = _persona.EliminarEmpleado(id);
            return Ok(response);

        }
    }
}
