using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostEmpleadoRequest
    {
        public int NumeroEmpleado { get; set; }
        public bool Estatus { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }

        // 

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string CURP { get; set; }
        public string Correo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
    }
}
