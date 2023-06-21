using Domain.Entities;
using Domain.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DAO
{
    public class PersonaRepositorio
    {
        private readonly ApplicationDbContext _context;

        public PersonaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Persona> ObtenerPersonas()
        {
            List<Persona> list = new List<Persona>();
            list = _context.Personas.Include(x => x.Empleado).ToList();
            return list;
        }

        /*public List<Empleado> ObtenerEmpleados()
        {
            List<Empleado> list = new List<Empleado>();
            list = _context.Empleados.ToList();
            return list;
        }*/


        public Empleado RegistrarEmpleado(PostEmpleadoRequest request)
        {
            Empleado empleado = new Empleado
            {
                NumEmpleado = request.NumeroEmpleado,
                Estatus = request.Estatus,
                FechaIngreso = request.FechaIngreso
            };

            _context.Empleados.Add(empleado);
            _context.SaveChanges();
            empleado = _context.Empleados.Where(e => e.NumEmpleado == request.NumeroEmpleado).FirstOrDefault();

            Persona persona = new Persona
            {
                Nombre = request.Nombre,
                Apellidos = request.Apellidos,
                CURP = request.CURP,
                Correo = request.Correo,
                FechaNacimeinto = request.FechaNacimiento,
                idEmpleado = empleado.Id
            };

            _context.Personas.Add(persona);
            _context.SaveChanges();
            return empleado;
        }

        public bool EliminarEmpleado(int id)
        {
            var response3 = _context.Personas.FirstOrDefault(e => e.Id == id);
            if (response3 == null)
            {
                return false;
            }
            var response2 = _context.Empleados.FirstOrDefault(e => e.Id == response3.idEmpleado);
            if (response2 == null)
            {
                return false;
            }
            _context.Empleados.Remove(response2);
            _context.SaveChanges();
            _context.Personas.Remove(response3);
            _context.SaveChanges();

            return true;
        }
    }
}
