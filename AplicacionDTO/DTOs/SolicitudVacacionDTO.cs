using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class SolicitudVacacionDTO
    {
        public int IdSolicitud { get; set; } // viene de SolicitudVacaciones.IdSolicitud
        public string Cedula { get; set; } // viene de Empleados.Cedula 
        public string NombreCompleto { get; set; }   // viene de Empleados.NombreCompleto
        public DateTime FechaInicio { get; set; }   // viene de SolicitudVacaciones.FechaInicio
        public DateTime FechaFin { get; set; } // viene de SolicitudVacaciones.FechaFin
        public string Estado { get; set; } // viene de SolicitudVacaciones.Estado
    }
}
