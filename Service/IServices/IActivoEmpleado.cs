using Domain.Entities;
using Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IActivoEmpleado
    {
        List<ActivoEmpleado> ObtenerActivosEmpleados();
        ActivoEmpleado RegistrarActivoEmpleado(PostActivoEmpleadoRequest request);
        bool EliminarActivoEmpleado(int id);
        bool EliminarActivoEmpleadoByEmpleado(int id);
    }
}
