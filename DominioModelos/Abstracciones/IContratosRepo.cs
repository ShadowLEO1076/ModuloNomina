using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Dominio.Modelos.Abstracciones
{
    public interface IContratosRepo : IRepositorio<Contratos>
    {
        Task<List<ContratoDTO>> ObtenerContratosCompletosAsync(); // Método para obtener todos los contratos con detalles completos
        Task<List<ContratoDTO>> ObtenerContratosPorEmpleadoAsync(string cedula); // Método para obtener contratos por empleado usando su cédula
        //Task<List<ContratoDTO>> ObtenerContratosVigentesAsync(DateTime fecha); // Método para obtener contratos vigentes en una fecha específica
       // Task<IEnumerable<Contratos>> BuscarPorFechaAsync(DateOnly fechaInicio); // Método para buscar contratos por rango de fechas
        Task<List<Contratos>> ObtenerContratosVencidosAsync();
        Task ActualizarContratoAsync(Contratos contrato);

    }
}


/*
 // Método para buscar contratos por rango de fechas contratos
Task<bool> ExisteContratoPorEmpleadoAsync(string cedula); // Método para verificar si existe un contrato por empleado
Task<bool> ExisteContratoPorFechaAsync(DateTime fechaInicio, DateTime fechaFin); // Método para verificar si existe un contrato por rango de fechas*/