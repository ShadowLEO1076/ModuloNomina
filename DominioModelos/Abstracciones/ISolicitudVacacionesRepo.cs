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
        Task<List<SolicitudVacacionDTO>> ObtenerResumenSolicitudesAsync();
    }
}
