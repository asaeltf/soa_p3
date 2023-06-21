using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.Extensions.Logging;
using Repository.Context;
using Repository.DAO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ActivoService : IActivo
    {
        private readonly ILogger<ActivoService> _logger;
        public readonly ActivoRepositorio activoRepositorio;

        public ActivoService(ILogger<ActivoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoRepositorio =  new ActivoRepositorio(context);
        }

        public List<Activo> ObtenerActivos()
        {
            List<Activo> activos = new List<Activo>();

            try
            {
                activos = activoRepositorio.ObtenerActivos();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activos;
        }

        public Activo RegistrarActivo(PostActivoRequest request)
        {
            var response = activoRepositorio.RegistrarActivo(request);
            return response;
        }
    }
}
