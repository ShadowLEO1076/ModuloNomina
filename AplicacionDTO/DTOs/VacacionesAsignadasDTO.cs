using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTO.DTOs
{
    public class VacacionesAsignadasDTO
    {
        public string NombreEmpleado { get; set; }
        public DateOnly FechaIngreso { get; set; }
        public int DiasOtorgadosAntes { get; set; }
        public int DiasOtorgadosNuevo { get; set; }
        public int DiasUsados { get; set; }
        public int DiasDisponibles => DiasOtorgadosNuevo - DiasUsados;
    }
}
