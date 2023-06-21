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
    public class ActivoEmpleadoController : Controller
    {
        private readonly IActivoEmpleado _activoEmpleado;

        public ActivoEmpleadoController(IActivoEmpleado activoEmpleado)
        {
            _activoEmpleado = activoEmpleado;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_activoEmpleado.ObtenerActivosEmpleados());
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public ActionResult<ActivoEmpleado> PostActivo([FromBody] PostActivoEmpleadoRequest request)
        {
            return Ok(_activoEmpleado.RegistrarActivoEmpleado(request));
        }

        [HttpDelete("{id}")]
        public ActionResult EliminarActivoEmpleado(int id)
        {
            var response = _activoEmpleado.EliminarActivoEmpleado(id);
            return Ok(response);

        }

    }
}
