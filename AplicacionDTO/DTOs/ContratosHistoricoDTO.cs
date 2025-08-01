using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class ContratosHistoricoDTO
    {
        public int IdHistorico { get; set; }

        public int IdContratoOriginal { get; set; }

        public int EmpleadoId { get; set; }

        public int TipoId { get; set; }

        public DateOnly FechaInicio { get; set; }

        public DateOnly? FechaFin { get; set; }

        public decimal Salario { get; set; }

        public string Estado { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string UsuarioCambio { get; set; }

        public DateTime? FechaRegistro { get; set; }
        public TimeOnly? JornadaHoraInicio { get; set; }

        public TimeOnly? JornadaHoraFin { get; set; }
    }
}
