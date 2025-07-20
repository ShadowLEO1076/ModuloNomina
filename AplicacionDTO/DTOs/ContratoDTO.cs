using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class ContratoDTO
    {
        public int IdContrato { get; set; }
        public int EmpleadoId { get; set; }
        public string CedulaEmpleado { get; set; }
        public string NombreCompletoEmpleado { get; set; }
        public string TipoContrato { get; set; }
        public string DescripcionTipoContrato { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Salario { get; set; }
        public string Estado { get; set; }
    }
}
