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
    public class ActivoEmpleadoService : IActivoEmpleado
    {
        private readonly ILogger<ActivoEmpleadoService> _logger;
        private readonly ActivoEmpleadoRepositorio activoEmpleadoRepositorio;

        public ActivoEmpleadoService(ILogger<ActivoEmpleadoService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            activoEmpleadoRepositorio = new ActivoEmpleadoRepositorio(context);
        }

        public List<ActivoEmpleado> ObtenerActivosEmpleados()
        {
            List<ActivoEmpleado> activosEmpleados = new List<ActivoEmpleado>();

            try
            {
                activosEmpleados = activoEmpleadoRepositorio.ObtenerActivosEmpleados();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return activosEmpleados;
        }

        public ActivoEmpleado RegistrarActivoEmpleado(PostActivoEmpleadoRequest request)
        {
            var response = activoEmpleadoRepositorio.RegistrarActivoEmpleado(request);
            return response;
        }

        public bool EliminarActivoEmpleado(int id)
        {
            var response = activoEmpleadoRepositorio.EliminarActivoEmpleado(id);
            return response;
        }

        public bool EliminarActivoEmpleadoByEmpleado(int id)
        {
            var response = activoEmpleadoRepositorio.EliminarActivoEmpleadoByEmpleado(id);
            return response;
        }
    }
}
