﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("Personas")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }
        [StringLength(18)]
        [Required]
        public string Apellidos { get; set; }
        [StringLength(13)]
        [Required]
        public string CURP { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaNacimeinto { get; set; }
        [StringLength(50)]
        [Required]
        public string Correo { get; set; }

        // Llaves foraneas

        [ForeignKey("Empleado")]
        public int? idEmpleado { get; set; }
        public virtual Empleado Empleado { get; set; }

    }
}
