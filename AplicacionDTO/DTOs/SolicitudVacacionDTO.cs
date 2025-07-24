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
        // empleado id
        public int IdEmpleado { get; set; } // viene de SolicitudVacaciones.IdSolicitud

        public string NombreCompleto { get; set; }   // viene de Empleados.NombreCompleto
        public string Cedula { get; set; } // viene de Empleados.Cedula 
        public DateOnly FechaInicio { get; set; }   // viene de SolicitudVacaciones.FechaInicio
        public DateOnly FechaFin { get; set; } // viene de SolicitudVacaciones.FechaFin
        public int DiasSolicitados { get; set; }
        public string Estado { get; set; } // viene de SolicitudVacaciones.Estado

        public DateTime FechaCreacion { get; set; } // viene de SolicitudVacaciones.FechaCreacion
    }
}
