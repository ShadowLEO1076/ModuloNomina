using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public  class DescuentoPorInasistenciaDTO
    {
        public int IdEmpleado { get; set; }
        public string NombresCompletos { get; set; }
        public string CedulaEmpleado { get; set; }
        public decimal SalarioBase { get; set; }
        public int CantidadInasistenciasNoRemunerables { get; set; }
        public decimal DescuentoTotal { get; set; }
    }
}
