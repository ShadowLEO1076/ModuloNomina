using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class EmpleadoContratoDTO
    {
        public string NombresEmple { get; set; }

        public string ApellidosEmple { get; set; }

        public string CedulaEmple { get; set; }

        public DateOnly FechaIngresoEmple { get; set; }

        public bool EstadoEmple { get; set; }

        public DateOnly FechaInicioContra { get; set; }

        public DateOnly? FechaFinContra { get; set; }

        public decimal SalarioContra { get; set; }

        public int? HorasJornadasContra { get; set; }

        public string EstadoContra { get; set; }

        public string JornadaContra { get; set; }
    }
}
