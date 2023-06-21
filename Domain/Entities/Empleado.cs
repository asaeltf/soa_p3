using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Empleados")]
    public class Empleado 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int NumEmpleado { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaIngreso { get; set; }
        [Required]
        public bool Estatus { get; set; }

    }
}
