using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class EmpleadoConSalarioDTO
    {
        public int IdEmpleado { get; set; }
        public string NombreCompleto { get; set; }
        public int PuestoId { get; set; }
        public string NombrePuesto { get; set; }
        public decimal SalarioBase { get; set; }
    }
}
