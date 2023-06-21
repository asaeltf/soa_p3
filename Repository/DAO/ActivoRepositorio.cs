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
    public class ActivoRepositorio
    {
        private readonly ApplicationDbContext _context;

        public ActivoRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Activo> ObtenerActivos()
        {
            List<Activo> list = new List<Activo>();
            list = _context.Activos.ToList();
            return list;
        }

        public Activo RegistrarActivo(PostActivoRequest request)
        {
            Activo response = new Activo
            {
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Estatus = request.Estatus
            };

            _context.Activos.Add(response);
            _context.SaveChanges();

            response = _context.Activos.Where(e => e.Descripcion == request.Descripcion).FirstOrDefault();
            return response;
        }
    }
}
