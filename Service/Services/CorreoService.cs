using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CorreoService : IEmail
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly IPersona _persona;
        private readonly ILogger<CorreoService> _logger;

        public CorreoService(IConfiguration configuration, SmtpClient smtpClient, IPersona persona, ILogger<CorreoService> logger)
        {
            _configuration = configuration;
            _smtpClient = smtpClient;
            _persona = persona;
            _logger = logger;
        }

        public string EnviarCorreos(PostEmailRequest request)
        {
            List<Persona> list = _persona.ObtenerPersonas();
            Console.WriteLine("////////////////////////////////////////////////");
            Console.WriteLine("Esta es la lista");
            foreach (var user in list)
            {
                Console.WriteLine(user.Correo);
            }
            Console.WriteLine("////////////////////////////////////////////////");
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_configuration["SmtpConfig:SmtpUsername"]);
                foreach (var user in list)
                {
                    mailMessage.To.Add(user.Correo.Trim());
                }
                mailMessage.Subject = "Mensaje enviado por SMTP de gmail";
                mailMessage.Body = request.Mensaje;
                _smtpClient.Send(mailMessage);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "Se envio el correo con exito!";
        }

        public string avisarEntregaActivo(PostEmailPersonRequest request)
        {

            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_configuration["SmtpConfig:SmtpUsername"]);
                    mailMessage.To.Add(request.Correo.Trim());
                mailMessage.Subject = "Mensaje enviado por SMTP de gmail";
                mailMessage.Body = request.Mensaje;
                _smtpClient.Send(mailMessage);

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return "Se envio el correo con exito!";
        }
    }
}
