using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTO.DTOs;
using Infraestructura.AccesoDatos;

namespace Dominio.Modelos.Abstracciones
{
    public interface ISolicitudVacacionesRepo : IRepositorio<SolicitudVacaciones>
    {
        Task<List<SolicitudVacacionDTO>> ObtenerResumenSolicitudesAsync(); // Método para obtener un resumen de solicitudes de vacaciones
        // obtener por estado aprovado o desaprobados pendiente 
        Task<List<SolicitudVacacionDTO>> ObtenerSolicitudesPorEstadoAsync(string estado); // Método para obtener solicitudes por estado
    }
}
