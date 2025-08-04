using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class AsistenciasDTO
    {

        public DateOnly Fecha { get; set; }

        public TimeOnly? HoraEntrada { get; set; }

        public TimeOnly? HoraSalida { get; set; }

        public bool? Estado { get; set; }

        public TimeOnly? HoraInicioAlmuerzo { get; set; }

        public TimeOnly? HoaFinAlmuerzo { get; set; }
    }
}
