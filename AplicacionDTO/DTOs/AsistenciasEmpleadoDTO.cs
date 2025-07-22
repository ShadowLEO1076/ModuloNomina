using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
   public class AsistenciasEmpleadoDTO
    {
        public string NombreCompleto { get; set; }

        public string Cedula { get; set; }

        public List<AsistenciasDTO> Asistencias { get; set; }
    }
}
