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
    public class PersonaService : IPersona
    {
        private readonly ILogger<PersonaService> _logger;
        public readonly PersonaRepositorio personaRepositorio;

        public PersonaService(ILogger<PersonaService> logger, ApplicationDbContext context)
        {
            _logger = logger;
            personaRepositorio = new PersonaRepositorio(context);
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                personas = personaRepositorio.ObtenerPersonas();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return personas;
        }

        public List<EmpleadoVM> ObtenerEmpleados()
        {
            List<EmpleadoVM> vm_empleado = new List<EmpleadoVM>();
            try
            {
                vm_empleado = personaRepositorio.ObtenerPersonas().Select(x => new EmpleadoVM()
                {
                    Id = x.Empleado.Id,
                    Nombre = x.Nombre,
                    Apellidos = x.Apellidos,
                    numeroEmpleado = x.Empleado.NumEmpleado,
                    Correo = x.Correo,
                    CURP = x.CURP,
                    estatus = x.Empleado.Estatus

                }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }

            return vm_empleado;
        }

        public Empleado RegistrarEmpleado(PostEmpleadoRequest request)
        {
            var response = personaRepositorio.RegistrarEmpleado(request);
            return response;
        }

        public bool EliminarEmpleado(int id)
        {
            var response = personaRepositorio.EliminarEmpleado(id);
            return response;
        }
    }
}
