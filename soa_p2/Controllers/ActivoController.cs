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
    public class ActivoController : Controller
    {
        private readonly IActivo _activo;

        public ActivoController(IActivo activo)
        {
            _activo = activo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_activo.ObtenerActivos());
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public ActionResult<Activo> PostActivo([FromBody] PostActivoRequest request)
        {
            return Ok(_activo.RegistrarActivo(request));
        }

        
    }
}
