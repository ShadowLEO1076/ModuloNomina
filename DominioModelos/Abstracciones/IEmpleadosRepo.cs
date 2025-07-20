using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.AccesoDatos;
using Aplicacion.DTO.DTOs;

namespace Dominio.Modelos.Abstracciones
{
    public interface IEmpleadosRepo: IRepositorio<Empleados>
    {
        //Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula); --> método de Guille

        Task<EmpleadoDTO> ObtenerEmpleadoDTOPorCedulaAsync(Empleados empleado);

       
    }
}
