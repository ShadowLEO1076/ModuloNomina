using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class VacacionesAprovadasGestionDTO  // este sirve para mostrar las vacaciones aprobadas y los días usados por empleado
    {
        //DATOS DE LA TABLA EMPLEADO 
        public string Cedula { get; set; } // viene de Empleados.Cedula
        public string NombreCompleto { get; set; } // viene de Empleados.NombreCompleto
        //DATOS DE LA TABLA SOLICITUD VACACIONES
        public string Estado { get; set; } // viene de SolicitudVacaciones.Estado
        //DATOS DE LA TABLA APROBACION VACACIONES
        public int IdAprobacion { get; set; } // viene de AprobacionVacaciones.IdAprobacion
        public DateTime FechaAprobacion { get; set; } // viene de AprobacionVacaciones.FechaAprobacion
        public string Aprobador { get; set; } // viene de AprobacionVacaciones.Aprobado
                                              // de empleados vacaciones totales:
        public int DiasOtorgados { get; set; } // Total de días de vacaciones otorgados al empleado

        public int DiasUsados { get; set; } // Total de días de vacaciones que el empleado ha utilizado


    }
}
