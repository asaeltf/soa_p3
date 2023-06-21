﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Requests
{
    public class PostEmailPersonRequest
    {
        [Required, MaxLength(50)]
        public string Mensaje { get; set; }

        [Required, MaxLength(50)]
        public string Correo { get; set; }
    }
}