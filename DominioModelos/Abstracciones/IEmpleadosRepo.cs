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
        Task<Empleados> ObtenerEmpleadoPorCedulaAsync(string cedula); // --> método de Guille
        Task<EmpleadoContratoDTO> ObtenerEmpleadoDTOPorCedulaAsync(string cedula);
        //Task<List<EmpleadoVacacionesDTO>> ObtenerResumenVacacionesAsync(); // Método para obtener un resumen de vacaciones de los empleados LEONARDO

        //Task<List<EmpleadoVacaciones>> ObtenerResumenVacacionesAsync(); // Método para obtener un resumen de vacaciones de los empleados LEONARDO
    }
}
