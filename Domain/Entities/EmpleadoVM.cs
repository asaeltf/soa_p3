using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpleadoVM
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public int numeroEmpleado { get; set; }
        public string Correo { get; set; }
        public string CURP { get; set; }
        public bool estatus { get; set; }

    }
}
