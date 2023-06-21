using Azure.Core;
using Domain.Entities;
using Domain.Models.Requests;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class ActivoEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ActivoEmpleadoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ActivoEmpleado> ObtenerActivosEmpleados()
        {
            List<ActivoEmpleado> list = new List<ActivoEmpleado>();
            list = _context.ActivosEmpleados.ToList();
            return list;
        }

        public ActivoEmpleado RegistrarActivoEmpleado(PostActivoEmpleadoRequest request)
        {
            DateTime dateToday = DateTime.Today;
            ActivoEmpleado response = new ActivoEmpleado
            {
                idEmpleado = request.IdentificadorEmpleado,
                idActivo = request.IdentificadoActivo,
                FechaAsignacion = DateTime.Today,
                FechaEntrega = request.FechaEntrega,
                FechaLiberacion = dateToday.AddDays(2)
            };

            _context.Add(response);
            _context.SaveChanges();

            Activo activo = _context.Activos.Where(e => e.Id == request.IdentificadoActivo).FirstOrDefault();
            activo.Estatus = true;
            _context.SaveChanges();
            Empleado empleado = _context.Empleados.Where(e => e.Id == request.IdentificadorEmpleado).FirstOrDefault();
            empleado.Estatus = true;
            _context.SaveChanges();
            return response;
        }

        public bool EliminarActivoEmpleado(int id)
        {
            var response = _context.ActivosEmpleados.FirstOrDefault(e => e.Id == id);
            if (response == null)
            {
                return false;
            }

            Activo activo = _context.Activos.Where(e => e.Id == response.idActivo).FirstOrDefault();
            activo.Estatus = false;
            _context.SaveChanges();
            Empleado empleado = _context.Empleados.Where(e => e.Id == response.idEmpleado).FirstOrDefault();
            empleado.Estatus = false;
            _context.SaveChanges();

            _context.ActivosEmpleados.Remove(response);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarActivoEmpleadoByEmpleado(int id)
        {
            return true;
        }
    }
}
