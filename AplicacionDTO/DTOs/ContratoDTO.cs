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
        public DateOnly? FechaInicio { get; set; }
        public TimeOnly? JornadaHoraInicio { get; set; }

        public TimeOnly? JornadaHoraFin { get; set; }

        public decimal Salario { get; set; }
        public DateTime FechaCreacion { get; set; }

        public DateTime FechaModificacion { get; set; }
        public int? HorasJornada { get; set; }
        public string Estado { get; set; }
       
    }
}
