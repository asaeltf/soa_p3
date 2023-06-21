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
    public class EmailController : Controller
    {
        private readonly IEmail _emailService;  
        public EmailController(IEmail correo)
        {
            _emailService = correo;
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostIMail([FromBody] PostEmailRequest request)
        {
            return Ok(_emailService.EnviarCorreos(request));
        }

        [HttpPost("avisarEntrega")]
        [SwaggerResponse((int)HttpStatusCode.Created)]
        public IActionResult PostIMail([FromBody] PostEmailPersonRequest request)
        {
            return Ok(_emailService.avisarEntregaActivo(request));
        }
    }
}
