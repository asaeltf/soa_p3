using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostActivoEmpleadoRequest
    {
        public int IdentificadorEmpleado { get; set; }
        public int IdentificadoActivo { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime FechaLiberacion { get; set; }
        public DateTime FechaEntrega { get; set; }
    }
}
