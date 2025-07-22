using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class InasistenciasEmpleadoDTO
    {
        public string NombresCompletos { get; set; }
        public string CedulaEmpleado { get; set; }
        public List<InasistenciasDTO> inasistencias { get; set; }
    }
}
