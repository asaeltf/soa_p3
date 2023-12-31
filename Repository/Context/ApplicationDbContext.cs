﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Activo> Activos { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<ActivoEmpleado> ActivosEmpleados { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
